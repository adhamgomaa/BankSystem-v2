using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BankSystem.API.Authorization;
using BankSystem.API.Configuration;
using BankSystem.API.Interfaces;
using BankSystem.Business.Interfaces;
using BankSystem.DTOs.Auth;
using BankSystem.Shared;
using Microsoft.IdentityModel.Tokens;

namespace BankSystem.API.Implementations;

public sealed class AuthService(
    JwtTokenSettings jwtSettings,
    IUserService userService,
    IRefreshTokenService refreshTokenService,
    ILoginAttemptService loginAttemptService) : IAuthService
{
    public async Task<LoginResponseDTO?> LoginAsync(
        LoginRequestDTO request,
        string? clientIpAddress,
        CancellationToken cancellationToken)
    {
        var user = await userService.FindUserAsync(request.UserName, cancellationToken);
        if (user is null)
        {
            await loginAttemptService.RecordAsync(
                null,
                request.UserName,
                false,
                clientIpAddress,
                cancellationToken);
            return null;
        }

        if (!user.isActive || !BCrypt.Net.BCrypt.Verify(request.Password, user.password))
        {
            await loginAttemptService.RecordAsync(
                user.userId,
                request.UserName,
                false,
                clientIpAddress,
                cancellationToken);
            return null;
        }

        await loginAttemptService.RecordAsync(
            user.userId,
            request.UserName,
            true,
            clientIpAddress,
            cancellationToken);

        var refreshToken = await refreshTokenService.CreateAsync(
            user.userId,
            Guid.NewGuid(),
            TimeSpan.FromDays(jwtSettings.RefreshTokenDays),
            cancellationToken);

        return CreateTokenResponse(user, refreshToken);
    }

    public async Task<LoginResponseDTO?> RefreshAsync(
        string refreshToken,
        CancellationToken cancellationToken)
    {
        var result = await refreshTokenService.RotateAsync(
            refreshToken,
            TimeSpan.FromDays(jwtSettings.RefreshTokenDays),
            cancellationToken);

        if (!result.Succeeded)
        {
            return null;
        }

        return CreateTokenResponse(result.User!, result.NewRefreshToken!);
    }

    public Task LogoutAsync(string refreshToken, CancellationToken cancellationToken)
    {
        return refreshTokenService.LogoutAsync(refreshToken, cancellationToken);
    }

    private LoginResponseDTO CreateTokenResponse(User user, string refreshToken)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.userId.ToString(CultureInfo.InvariantCulture)),
            new Claim(ClaimTypes.Name, user.username),
            new Claim(BankClaimTypes.Permissions, user.permissions.ToString(CultureInfo.InvariantCulture))
        };

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SigningKey));
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.AccessTokenMinutes),
            signingCredentials: signingCredentials);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        return new LoginResponseDTO(accessToken, refreshToken);
    }
}
