using System.ComponentModel.DataAnnotations;

namespace BankSystem.DTOs.Auth;

public sealed record RefreshTokenRequestDTO
{
    /// <summary>The refresh token issued during login or a previous refresh.</summary>
    [Required]
    public required string RefreshToken { get; init; }
}
