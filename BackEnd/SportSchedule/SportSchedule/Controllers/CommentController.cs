using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.DataTranserferObject.Comment;
using SportSchedule.Services.Comment;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        //Them comment
        [Authorize(Roles = "Member", Policy = "permission.Comment")]
        [HttpPost]
        public async Task<IActionResult> addComment(CommentDTO comment)
        {
            string username = User.Identity.Name;
            await _commentService.addComment(comment, username);
            return Ok();
        }

        //Lay comment theo bai viet(Khong co phan hoi)
        [HttpGet("comment/{postId}")]
        public async Task<IActionResult> getComments(int postId)
        {
            var data = await _commentService.getComments(postId);
            if(data == null) 
                return NotFound();
            return Ok(data);
        }

        //Lay nhung comment phan hoi
        [HttpGet("comment/reply/{commentId}")]
        public async Task<IActionResult> getCommentsReply(int commentId)
        {
            var data = await _commentService.getCommentsReply(commentId);
            if( data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
