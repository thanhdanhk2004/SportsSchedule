using SportSchedule.DataTranserferObject.Article;

namespace SportSchedule.Services.Article
{
    public interface IArticleService
    {
        Task postArticle(ArticleDTO article);
        Task updateArticle(ArticleDTO article);
        Task deleteArticle(int? article_id);
        Task<ArticleDTOFE> getArticle(int? article_id);
    }
}
