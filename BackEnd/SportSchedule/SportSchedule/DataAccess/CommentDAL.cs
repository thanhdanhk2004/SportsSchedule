using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Comment;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class CommentDAL
    {
        private readonly ContextDB _context;
        private readonly UserDAL _userDAL;
        public CommentDAL(ContextDB context, UserDAL userDAL)
        {
            _context = context;
            _userDAL = userDAL;
        }

        public void addComment(CommentDTO comment, string username)
        {
            try
            {
                if (comment == null || username == null)
                    return;
                CommentModel model = new CommentModel
                {
                    Content = comment.Content,
                    Created = DateTime.UtcNow,
                    PostId = comment.PostId,
                    UserId = _userDAL.getUserId(username),
                    CommendIdReply = comment.CommentReplyId,
                };
                _context.Comment.Add(model);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        //Lay danh sach comments (Binh luan truc tiep bai viet)
        public List<CommentDTOFE> getComments(int postId)
        {
            try
            {
                if (postId == 0)
                    return null;
                var comments = _context.Comment.Include(c => c.User)
                                .Where(c => c.PostId == postId && c.CommendIdReply == null)
                                .OrderByDescending(c => c.Created)
                                .Select(c => new CommentDTOFE
                                {
                                    CommentId = c.CommentId,
                                    Content = c.Content,
                                    TimeComment = c.Created.Value.ToString("dd/MM/yyyy"),
                                    AuthorNameComment = c.User.LastName + " " + c.User.FirstName,
                                    TotalCommentReply = _context.Comment.Count(cr => cr.CommendIdReply == c.CommentId)
                                })
                                .ToList();
                return comments;
            }catch(Exception ex)
            {
                return null;
            }
        }

        //Lay danh sach binh luan phan hoi mot binh luan
        public List<CommentDTOFE> getCommentByReply(int comment_id)
        {
            try
            {
                if (comment_id == 0)
                    return null;
                var comments = _context.Comment
                                .Include(c => c.User)
                                .Where(c => c.CommendIdReply == comment_id)
                                .Select(c => new CommentDTOFE
                                {
                                    CommentId = c.CommentId,
                                    Content = c.Content,
                                    TimeComment = c.Created.Value.ToString("dd/MM/yyyy hh:mm"),
                                    AuthorNameComment = c.User.LastName + " " + c.User.FirstName,
                                    TotalCommentReply = _context.Comment.Count(cr => cr.CommendIdReply == c.CommentId)
                                }).ToList();
                return comments;
            }catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        
    }
}
