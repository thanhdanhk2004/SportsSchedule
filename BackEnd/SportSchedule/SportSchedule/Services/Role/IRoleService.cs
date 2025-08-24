using SportSchedule.DataTranserferObject.Role;

namespace SportSchedule.Services.Role
{
    public interface IRoleService
    {
        Task<List<RoleDTOFE>> getRoles();
    }
}
