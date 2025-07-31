using Microsoft.AspNetCore.Authorization;

namespace SportSchedule.Services.Permission
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var permission = context.User.HasClaim("permission", requirement.Permission);
            if (permission)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
