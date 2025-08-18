using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Article;

namespace SportSchedule.Services.Article
{
    public class ArticleService : IArticleService
    {
        private readonly PostDAL _postDAL;
        
        public ArticleService(PostDAL postDAL)
        {
            _postDAL = postDAL;
        }

        public async Task deleteArticle(int? article_id)
        {
            if (article_id == null)
                return;
            _postDAL.deleteArticle(article_id);
        }

        public async Task<List<ArticleDTOFE>> getArticlesByUserId(string username)
        {
            var data = _postDAL.GetArticlesByUserId(username);
            return data;
        }

        public async Task<ArticleDTOFE> getArticleByArticleId(int? article_id)
        {
            if (!article_id.HasValue)
                return null;
            return _postDAL.getArticleByArticleId(article_id.Value);
        }

        public async Task postArticle(ArticleDTO article, string username)
        {
            if(article == null)
                return;
            _postDAL.addArticle(article, username);
        }

        public async Task updateArticle(ArticleDTO article, int articleId)
        {
            if (article == null)
                return;
            _postDAL.updateArticle(article, articleId);
        }

        public async Task<List<ArticlePageDTOFE>> getArticlesByPage(int page)
        {
            if (page == null)
                return null;
            return _postDAL.getArticleByPage(page);
        }
    }
}
