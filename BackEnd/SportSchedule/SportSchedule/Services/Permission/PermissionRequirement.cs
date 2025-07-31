using Microsoft.AspNetCore.Authorization;

namespace SportSchedule.Services.Permission
{
    public class PermissionRequirement:IAuthorizationRequirement
    {
        public string Permission { get; }
        public PermissionRequirement(string permission)
        {
            this.Permission = permission;
        }
    }
}
