namespace SportSchedule.Model
{
    public class PermissionModel
    {
        public int? PermissionId { get; set; }
        public string? PermisstionName {  get; set; }
        public List<RolePermissionModel>? RolePermissions { get; set; }
    }
}
