namespace BankSystem.API.Authorization;

[Flags]
public enum BankPermission
{
    People = 1,
    Client = 2,
    Transfer = 4,
    Registration = 8,
    User = 16,
    FullAccess = -1
}
