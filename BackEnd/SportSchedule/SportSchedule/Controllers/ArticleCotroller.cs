using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.DataTranserferObject.Article;
using SportSchedule.Services.Article;
using System.Security.Claims;

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

        //Xem bai viet theo id bai viet
        [HttpGet("{articleId}")]
        public async Task<IActionResult> getArticleByArticleId(int articleId)
        {
            var data = await _articleService.getArticleByArticleId(articleId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        //Xem bai viet theo id user
        [Authorize(Roles = "Member", Policy = ("permission.HistoryArticle"))]
        [HttpGet("history")]
        public async Task<IActionResult> getArticleByUserId()
        {
            string username = User.Identity.Name;
            var data = await _articleService.getArticlesByUserId(username);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        //Dang bai viet
        [Authorize(Roles = "Member, Admin", Policy = ("permission.PostArticles"))]
        [HttpPost("post")]
        public async Task<IActionResult> postArticle(ArticleDTO article)
        {
            string username = User.Identity.Name;
            await _articleService.postArticle(article, username);
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
