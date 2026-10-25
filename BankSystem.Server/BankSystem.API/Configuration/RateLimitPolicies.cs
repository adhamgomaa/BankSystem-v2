namespace BankSystem.API.Configuration;

public static class RateLimitPolicies
{
    public const string Login = nameof(Login);
    public const string Refresh = nameof(Refresh);
    public const string UserWrites = nameof(UserWrites);
}
