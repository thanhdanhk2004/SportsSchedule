namespace SportSchedule.Model
{
    public class RolePermissionModel
    {
        public int? RoleId { get; set; }
        public int? PermissionId {  get; set; }
        public RoleModel? Role { get; set; }
        public PermissionModel? Permission { get; set; }
    }
}
