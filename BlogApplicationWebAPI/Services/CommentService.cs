using BlogApplicationWebAPI.Database;
using BlogApplicationWebAPI.Entitys;

namespace BlogApplicationWebAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly BlogContext Context = null;
        public CommentService(BlogContext context)
        {
            Context = context;  
        }

        public void AddComment(Comment comment)
        {
            Context.Comments.Add(comment);
            Context.SaveChanges();
               
        }

        public void  DeleteComment(int commentId)
        {
            var commentToDelete = Context.Comments.SingleOrDefault(c=>c.Id==commentId);
            if (commentToDelete != null)
            {
                Context.Comments.Remove(commentToDelete);
                Context.SaveChanges();
                
            }
           
        }

        public List<Comment> GetComment()
        {
            var res= Context.Comments.ToList();
            return res;
        }

        public Comment GetCommentById(int commentId)
        {
            var res = Context.Comments.Find(commentId);
            return res;
        }

        

        public void UpdateComment(Comment comment)
        {
            if(comment!=null)
            {
                Context.Comments.Update(comment);
                Context.SaveChanges();
                
            }
            
        }
    }
}
