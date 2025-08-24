namespace SportSchedule.DataTranserferObject.Permission
{
    public class PermissionDTO
    {
        public int? PermissionId { get; set; }
        public string? PermissionName {  get; set; }
        public List<int>? ListRoleId { get; set; }
    }
}
