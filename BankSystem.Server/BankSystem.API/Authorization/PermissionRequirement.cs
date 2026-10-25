using Microsoft.AspNetCore.Authorization;

namespace BankSystem.API.Authorization;

public sealed class PermissionRequirement(int requiredPermission) : IAuthorizationRequirement
{
    public int RequiredPermission { get; } = requiredPermission;
}
