using SportSchedule.DataTranserferObject.Permission;
using SportSchedule.Model;

namespace SportSchedule.Services.Permission
{
    public interface IPermissionService
    {
        Task<List<PermissionDTOFE>> getPermissions();
        Task<bool> addPermission(PermissionDTO permissionDTO);
        Task<bool> deletePermission(int permissionId);
        Task<bool> updatePermission(PermissionDTO permisison);
    }
}
