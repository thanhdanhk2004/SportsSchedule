using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Comment;

namespace SportSchedule.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly CommentDAL _commentDAL;
        public CommentService(CommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        public async Task addComment(CommentDTO comment, string username)
        {
            _commentDAL.addComment(comment, username);
        }

        public async Task<List<CommentDTOFE>> getComments(int postId)
        {
            var data = _commentDAL.getComments(postId);
            return data;
        }

        public async Task<List<CommentDTOFE>> getCommentsReply(int commentId)
        {
            var data = _commentDAL.getCommentByReply(commentId);
            return data;
        }
    }
}
