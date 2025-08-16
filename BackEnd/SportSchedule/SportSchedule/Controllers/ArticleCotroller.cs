using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.DataTranserferObject.Article;
using SportSchedule.Services.Article;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/article")]
    public class ArticleCotroller : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleCotroller(IArticleService articleService)
        {
            _articleService = articleService;
        }

        //Xem bai viet
        [HttpGet("{articleId}")]
        public async Task<IActionResult> getArticle(int articleId)
        {
            var data = await _articleService.getArticle(articleId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        //Dang bai viet
        [Authorize(Roles = "Member, Admin", Policy = ("permission.PostArticles"))]
        [HttpPost("post")]
        public async Task<IActionResult> postArticle(ArticleDTO article)
        {
            await _articleService.postArticle(article);
            return Ok();
        }

        //Chinh sua bai viet
        
        [Authorize(Policy = "Permission.PostArticle")]
        [HttpPut("{articleId}")]
        public async Task<IActionResult> updateArticle(ArticleDTO article)
        {
            await _articleService.updateArticle(article);
            return Ok();
        }

        //Xoa bai viet
        [Authorize(Roles = "Admin,Member")]
        [HttpDelete("{articleId}")]
        public async Task<IActionResult> deleteArticle(int articleId)
        {
            await _articleService.deleteArticle(articleId);
            return Ok();
        }
    }
}
