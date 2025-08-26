using System.ComponentModel.DataAnnotations;

namespace SportSchedule.Model
{
    public class UserModel
    {
        public int? UserId {  get; set; }
        public string? LastName { get; set; }
        public string? FirstName {  get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public int RoleId {  get; set; }
        public RoleModel? Role { get; set; }
        public AccountModel? Account { get; set; }
        public List<PostModel>? Posts { get; set; }
        public List<CommentModel>? Comments { get; set; }
        public List<GuessModel>? Guess { get; set; }
        public List<AppointmentModel>? Appointments { get; set; }

    }
}
