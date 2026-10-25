using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace BankSystem.API.Authorization;

public sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var permissionClaim = context.User.FindFirst(BankClaimTypes.Permissions);
        if (permissionClaim is not null &&
            int.TryParse(
                permissionClaim.Value,
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var userPermissions) &&
            (userPermissions == (int)BankPermission.FullAccess ||
                (userPermissions >= 0 &&
                (userPermissions & requirement.RequiredPermission) == requirement.RequiredPermission)))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
