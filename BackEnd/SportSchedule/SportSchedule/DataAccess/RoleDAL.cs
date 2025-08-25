using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Role;
using SportSchedule.Model;

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

        public bool addRole(string roleName)
        {
            try
            {
                if(roleName  == null) 
                    return false;
                RoleModel role = new RoleModel
                {
                    Id = _context.Roles.Count() + 1,
                    Name = roleName,
                };
                _context.Roles.Add(role);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool removeRole(int roleId)
        {
            try
            {
                if(roleId == null)
                    return false;
                var role = _context.Roles.FirstOrDefault(r => r.Id == roleId);
                if(role == null)
                    return false;
                _context.Roles.Remove(role);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool updateRole(int roleId, string roleName)
        {
            try
            {
                if (roleName == null)
                    return false;
                var role = _context.Roles.FirstOrDefault(r =>r.Id == roleId);
                if( role == null)
                    return false;
                role.Name = roleName;
                _context.Roles.Update(role);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
