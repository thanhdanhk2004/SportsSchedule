namespace SportSchedule.Model
{
    public class CommentModel
    {
        public string? CommentId {  get; set; }
        public string? Content {  get; set; }
        public DateTime? Created {  get; set; }
        public string? PostId {  get; set; }
        public string? UserId {  get; set; }
        public string? CommendIdReply { get; set; }
        public UserModel? User { get; set; }
        public PostModel? Post { get; set; }
        public List<CommentModel>? Comments { get; set; }
        public CommentModel? Comment { get; set; }
    }
}
