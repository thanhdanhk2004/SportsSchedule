using SportSchedule.DataTranserferObject.Article;

namespace SportSchedule.Services.Article
{
    public interface IArticleService
    {
        Task postArticle(ArticleDTO article, string username);
        Task updateArticle(ArticleDTO article);
        Task deleteArticle(int? article_id);
        Task<ArticleDTOFE> getArticleByArticleId(int? article_id);
        Task<List<ArticleDTOFE>> getArticlesByUserId(string username);
    }
}
