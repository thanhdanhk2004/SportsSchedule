using SportSchedule.DataTranserferObject.Comment;

namespace SportSchedule.Services.Comment
{
    public interface ICommentService
    {
        Task<List<CommentDTOFE>> getComments(int postId);
        Task<List<CommentDTOFE>> getCommentsReply(int commentId);
        Task addComment(CommentDTO comment, string username);

    }
}
