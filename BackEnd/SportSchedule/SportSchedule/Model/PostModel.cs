namespace SportSchedule.Model
{
    public class PostModel
    {
        public int? PostId {  get; set; }
        public string? Title {  get; set; }
        public string? Description { get; set; }
        public string? Image {  get; set; }
        public DateTime? Created { get; set; } = DateTime.UtcNow;
        public int? UserId { get; set; }
        public string? Status {  get; set; }
        public UserModel? User { get; set; }
        public List<CommentModel>? Comments { get; set; }
    }
}
