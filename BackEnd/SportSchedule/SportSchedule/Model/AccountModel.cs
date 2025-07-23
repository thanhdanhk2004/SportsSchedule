namespace SportSchedule.Model
{
    public class AccountModel
    {
        public int? AccountId {  get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? UserId {  get; set; }
        public UserModel? User { get; set; }
        
    }
}
