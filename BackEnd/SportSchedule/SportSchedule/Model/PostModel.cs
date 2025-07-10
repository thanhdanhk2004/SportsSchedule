namespace SportSchedule.Model
{
    public class PostModel
    {
        public string? PostId {  get; set; }
        public string? Title {  get; set; }
        public string? Description { get; set; }
        public string? Image {  get; set; }
        public DateTime? Created { get; set; } = DateTime.UtcNow;
        public string? UserId { get; set; }
        public UserModel? User { get; set; }
        public List<CommentModel>? Comments { get; set; }
    }
}
