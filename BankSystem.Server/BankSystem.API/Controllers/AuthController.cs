using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankSystem.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using BankSystem.API.Configuration;
using BankSystem.API.Interfaces;

namespace BankSystem.API.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login", Name = "Login")]
        [AllowAnonymous]
        [EnableRateLimiting(RateLimitPolicies.Login)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<LoginResponseDTO>> Login(
            LoginRequestDTO loginRequest,
            CancellationToken cancellationToken)
        {
            var clientIpAddress = HttpContext.Connection.RemoteIpAddress?.MapToIPv6().ToString();
            var tokens = await authService.LoginAsync(loginRequest, clientIpAddress, cancellationToken);
            if (tokens is null)
                return Unauthorized("Invalid Credentials");

            return Ok(tokens);
        }

        [HttpPost("refresh", Name = "Refresh")]
        [AllowAnonymous]
        [EnableRateLimiting(RateLimitPolicies.Refresh)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<LoginResponseDTO>> Refresh(
            RefreshTokenRequestDTO request,
            CancellationToken cancellationToken)
        {
            var tokens = await authService.RefreshAsync(request.RefreshToken, cancellationToken);
            if (tokens is null)
                return Unauthorized("Invalid or expired refresh token");

            return Ok(tokens);
        }

        [HttpPost("logout", Name = "Logout")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logout(
            RefreshTokenRequestDTO request,
            CancellationToken cancellationToken)
        {
            await authService.LogoutAsync(request.RefreshToken, cancellationToken);
            return NoContent();
        }
    }
}
