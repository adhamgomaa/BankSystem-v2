using BankSystem.Shared;

namespace BankSystem.Business;

public sealed record RefreshTokenRefreshResult(
    User? User,
    string? NewRefreshToken)
{
    public bool Succeeded => User is not null && NewRefreshToken is not null;
}
