using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Permission;
using SportSchedule.Model;

namespace SportSchedule.Services.Permission
{
    public class PermissionService:IPermissionService
    {
        private readonly PermissionDAL _permissionDAL;
        public PermissionService(PermissionDAL permissionDAL)
        {
            _permissionDAL = permissionDAL;
        }

        public async Task<bool> addPermission(PermissionDTO permissionDTO)
        {
            try
            {
                if(permissionDTO == null) 
                    return false;
                return _permissionDAL.addPermisison(permissionDTO);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> deletePermission(int permissionId)
        {
            try
            {
                if (permissionId == 0) 
                    return false;
                return _permissionDAL.deletePermission(permissionId);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<PermissionDTOFE>> getPermissions()
        {
            try
            {
                return _permissionDAL.getPermissions();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        public async Task<bool> updatePermission(PermissionDTO permisison)
        {
            try
            {
                if(permisison == null)
                    return false;
                return _permissionDAL.updatePermission(permisison);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
