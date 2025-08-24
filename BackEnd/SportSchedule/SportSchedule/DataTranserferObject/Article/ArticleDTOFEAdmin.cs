namespace SportSchedule.DataTranserferObject.Article
{
    public class ArticleDTOFEAdmin
    {
        public int? ArticleId { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CreatedDate {  get; set; }
        public string? Status { get; set; }
        public string? UserName {  get; set; }

        public int TotalPage { get; set; }
        
    }
}
