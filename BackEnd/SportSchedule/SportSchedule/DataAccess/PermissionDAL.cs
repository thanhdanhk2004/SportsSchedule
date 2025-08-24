using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Permission;
using SportSchedule.Model;
using System.Security;

namespace SportSchedule.DataAccess
{
    public class PermissionDAL
    {
        private readonly ContextDB _context;
        public PermissionDAL(ContextDB context)
        {
            _context = context;
        }

        //Them permission
        public bool addPermisison(PermissionDTO permissionDTO)
        {
            try
            {
                if (permissionDTO == null)
                    return false;
                PermissionModel permission = new PermissionModel
                {
                    PermissionId = _context.Permissions.Count() + 1,
                    PermisstionName = permissionDTO.PermissionName,
                };
                _context.Permissions.Add(permission);
                _context.SaveChanges();

                if(permissionDTO.ListRoleId != null)
                {
                    foreach (int roleId in permissionDTO.ListRoleId)
                    {
                        RolePermissionModel model = new RolePermissionModel
                        {
                            RoleId = roleId,
                            PermissionId = permission.PermissionId,
                        };
                        _context.RolePermissions.Add(model);
                        _context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        // xoa permission 
        public bool deletePermission(int permissionId)
        {
            try
            {
                var permission = _context.Permissions.FirstOrDefault(p => p.PermissionId == permissionId);
                if (permission == null)
                    return false;
                _context.Permissions.Remove(permission);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        //cap nhat permission 
        public bool updatePermission(PermissionDTO permissionDTO)
        {
            try
            {
                if (permissionDTO == null)
                    return false;
                var model = _context.Permissions
                    .FirstOrDefault(p => p.PermissionId == permissionDTO.PermissionId);
                if (model == null)
                    return false;
                //Cap nhat permission name
                model.PermisstionName = permissionDTO.PermissionName;
                _context.Permissions.Update(model);
                _context.SaveChanges();

                //Xoa cac hang chua rolepermission nay
                var rolePermission = _context.RolePermissions.Where(rp => rp.PermissionId == permissionDTO.PermissionId).ToList();
                _context.RolePermissions.RemoveRange(rolePermission);
                _context.SaveChanges();

                //Them lai
                if(permissionDTO.ListRoleId != null)
                {
                    foreach(var roleId in permissionDTO.ListRoleId)
                    {
                        RolePermissionModel rp = new RolePermissionModel
                        {
                            RoleId = roleId,
                            PermissionId = model.PermissionId,
                        };
                        _context.RolePermissions.Add(rp);
                        _context.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        //Lay danh sach permission 
        public List<PermissionDTOFE> getPermissions()
        {
            try
            {
                var permissions = (from p in _context.Permissions
                                   join rp in _context.RolePermissions on p.PermissionId equals rp.PermissionId into pGroup
                                   from rpp in pGroup.DefaultIfEmpty()
                                   join r in _context.Roles on rpp.RoleId equals r.Id into rGroup
                                   select new
                                   {
                                       PermissionId = p.PermissionId,
                                       PermissionName = p.PermisstionName,
                                       RoleName = rGroup.Select(x => x.Name).FirstOrDefault()
                                   }).GroupBy(x => new { x.PermissionId, x.PermissionName })
                                     .Select(g => new PermissionDTOFE
                                     {
                                          PermissionId = g.Key.PermissionId,
                                          PermissionName = g.Key.PermissionName,
                                          RoleName = g.Select(x => x.RoleName).ToList()
                                     }).ToList();

                return permissions;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }
    }
}
