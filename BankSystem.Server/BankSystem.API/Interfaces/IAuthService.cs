using BankSystem.DTOs.Auth;

namespace BankSystem.API.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDTO?> LoginAsync(
        LoginRequestDTO request,
        string? clientIpAddress,
        CancellationToken cancellationToken);

    Task<LoginResponseDTO?> RefreshAsync(
        string refreshToken,
        CancellationToken cancellationToken);

    Task LogoutAsync(string refreshToken, CancellationToken cancellationToken);
}
