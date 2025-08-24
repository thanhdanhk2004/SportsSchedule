using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Role;

namespace SportSchedule.DataAccess
{
    public class RoleDAL
    {
        private readonly ContextDB _context;
        public RoleDAL(ContextDB context)
        {
            _context = context;
        }

        public List<RoleDTOFE> getRoles()
        {
            try
            {
                var data = _context.Roles
                    .Select(r => new RoleDTOFE
                    {
                        RoleName = r.Name,
                        RoleId = r.Id,
                    }).ToList();
                return data;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }
    }
}
