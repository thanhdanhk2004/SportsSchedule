using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Role;

namespace SportSchedule.Services.Role
{
    public class RoleService:IRoleService
    {
        private readonly RoleDAL _roleDAL;
        public RoleService(RoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public async Task<bool> addRole(string roleName)
        {
            try
            {
                if (roleName == null)
                    return false;
                return _roleDAL.addRole(roleName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<RoleDTOFE>> getRoles()
        {
            try
            {
                return _roleDAL.getRoles();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        public async Task<bool> removeRole(int roleId)
        {
            try
            {
                if (roleId == null)
                    return false;
                return _roleDAL.removeRole(roleId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> updateRole(int roleId, string roleName)
        {
            try
            {
                if (roleName == null)
                    return false;
                return _roleDAL.updateRole(roleId, roleName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
