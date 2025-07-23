namespace SportSchedule.Model
{
    public class CommentModel
    {
        public int? CommentId {  get; set; }
        public string? Content {  get; set; }
        public DateTime? Created { get; set; } = DateTime.UtcNow;
        public int? PostId {  get; set; }
        public int? UserId {  get; set; }
        public int? CommendIdReply { get; set; }
        public UserModel? User { get; set; }
        public PostModel? Post { get; set; }
        public List<CommentModel>? Comments { get; set; }
        public CommentModel? Comment { get; set; }
    }
}
