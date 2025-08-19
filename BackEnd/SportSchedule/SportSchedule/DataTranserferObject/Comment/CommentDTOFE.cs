namespace SportSchedule.DataTranserferObject.Comment
{
    public class CommentDTOFE
    {
        public int? CommentId { get; set; }
        public string? Content {  get; set; }
        public string? AuthorNameComment {  get; set; }
        public string? TimeComment {  get; set; }
        public int? TotalCommentReply {  get; set; }
    }
}
