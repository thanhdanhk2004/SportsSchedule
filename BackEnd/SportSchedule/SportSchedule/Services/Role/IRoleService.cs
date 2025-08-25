using SportSchedule.DataTranserferObject.Role;

namespace SportSchedule.Services.Role
{
    public interface IRoleService
    {
        Task<List<RoleDTOFE>> getRoles();
        Task<bool> addRole(string roleName);
        Task<bool> removeRole(int roleId);  
        Task<bool> updateRole(int roleId, string roleName);
    }
}
