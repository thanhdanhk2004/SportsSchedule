using System.ComponentModel.DataAnnotations;

namespace SportSchedule.Model
{
    public enum Role
    {
        Admin = 1,
        Member = 2
    }
    public class UserModel
    {
        
        public string? UserId {  get; set; }
        public string? LastName { get; set; }
        public string? FirstName {  get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public Role? Role { get; set; }
        public AccountModel? Account { get; set; }
        public List<PostModel>? Posts { get; set; }
        public List<CommentModel>? Comments { get; set; }
        public List<MessageModel>? MessageSends {  get; set; }
        public List<MessageModel>? MessageRevices {  get; set; }
        public List<GuessModel>? Guess { get; set; }

    }
}
