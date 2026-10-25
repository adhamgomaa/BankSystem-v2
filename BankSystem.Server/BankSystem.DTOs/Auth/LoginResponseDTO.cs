namespace BankSystem.DTOs.Auth;

/// <summary>Contains the access and refresh tokens issued after authentication.</summary>
public sealed record LoginResponseDTO(string AccessToken, string RefreshToken);
