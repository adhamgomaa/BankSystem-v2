namespace BankSystem.API.Authorization;

public static class PermissionPolicies
{
    public const string People = nameof(People);
    public const string Client = nameof(Client);
    public const string Transfer = nameof(Transfer);
    public const string Registration = nameof(Registration);
    public const string User = nameof(User);
    public const string FullAccess = nameof(FullAccess);
}
