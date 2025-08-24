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

        //Xem bai viet theo trang (Khon can dang nhap van xem duoc)
        [HttpGet("articles/{page}")]
        public async Task<IActionResult> getArticlesByPage(int page)
        {
            var data = await _articleService.getArticlesByPage(page-1);
            if(data == null)
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
        
        [Authorize(Policy = "permission.UpdateArticle", Roles = "Member")]
        [HttpPut("update/{articleId}")]
        public async Task<IActionResult> updateArticle(int articleId, ArticleDTO article)
        {
            await _articleService.updateArticle(article, articleId);
            return Ok();
        }

        //Xoa bai viet
        [Authorize(Roles = "Admin,Member", Policy ="permission.DeleteArticle")]
        [HttpDelete("delete/{articleId}")]
        public async Task<IActionResult> deleteArticle(int articleId)
        {
            await _articleService.deleteArticle(articleId);
            return Ok();
        }

        //Cap nhat trang thai bai viet (duyet bai viet)
        [Authorize(Roles ="Admin", Policy = "permission.ApproveArticles")]
        [HttpPatch("/admin/update/status/{article_id}")]
        public async Task<IActionResult> updateStatusArticle(int article_id)
        {
            var result = await _articleService.updateStatusArticle(article_id);
            if (result == false)
                return BadRequest();
            return Ok();
        }

        //Lay danh sach bai viet do ra FE
        [HttpGet("/admin/articles/{page}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getArticleByPageAdmin(int page)
        {
            var data = await _articleService.getArticleByPageAdmin(page);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
