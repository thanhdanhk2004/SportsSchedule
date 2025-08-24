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
    }
}
