namespace BankSystem.API.Configuration;

public sealed record JwtTokenSettings(
    string Issuer,
    string Audience,
    string SigningKey,
    int AccessTokenMinutes,
    int RefreshTokenDays);
