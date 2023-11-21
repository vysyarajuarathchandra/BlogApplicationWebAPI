using BlogApplicationWebAPI.Entitys;

namespace BlogApplicationWebAPI.Services
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
        void  DeleteComment(int commentId);
        Comment GetCommentById(int commentId);
        List<Comment> GetComment();
        
    }
}
