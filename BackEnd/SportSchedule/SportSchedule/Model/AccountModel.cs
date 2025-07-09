namespace SportSchedule.Model
{
    public class AccountModel
    {
        public string? AccountId {  get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? UserId {  get; set; }
        public UserModel? User { get; set; }
        
    }
}
