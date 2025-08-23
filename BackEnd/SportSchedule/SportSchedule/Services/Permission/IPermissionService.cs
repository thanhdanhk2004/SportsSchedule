using SportSchedule.DataTranserferObject.Permission;
using SportSchedule.Model;

namespace SportSchedule.Services.Permission
{
    public interface IPermissionService
    {
        Task<List<PermissionDTOFE>> getPermissions();
        Task<bool> addPermission(string permissionName);
        Task<bool> deletePermission(int permissionId);
        Task<bool> updatePermission(PermissionModel permisison);
    }
}
