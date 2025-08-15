namespace SportSchedule.DataTranserferObject.Article
{
    public class ArticleDTO
    {
        public int? ArticleId { get; set; }
        public string? Title {  get; set; }
        public string? Description { get; set; }
        public string? Image {  get; set; }
        public int? UserId { get; set; }
        public string? Status {  get; set; }
    }
}
