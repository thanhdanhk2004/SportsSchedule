namespace SportSchedule.Model
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public UserModel? User { get; set; }
    }
}
