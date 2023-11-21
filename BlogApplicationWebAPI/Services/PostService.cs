using BlogApplicationWebAPI.Database;
using BlogApplicationWebAPI.Entitys;

namespace BlogApplicationWebAPI.Services
{
    public class PostService : IPostService
    {
        private readonly BlogContext Context =null;
        public PostService (BlogContext context)
        {
            this.Context = context;
        }
        public void AddPost(Post post)
        {
            Context.Posts.Add(post);
            Context.SaveChanges();
            
        }

        public void DeletePost(int postId)
        {
            var postToDelete = Context.Posts.SingleOrDefault(p => p.PostId == postId);
            if (postToDelete != null)
            {
                Context.Posts.Remove(postToDelete);
                Context.SaveChanges();
                
            }
          
        }

        public List<Post> GetPost()
        {
            var res = Context.Posts.ToList();
            return res;
        }

        public Post GetPostById(int postId)
        {
            var res=Context.Posts.Find(postId);
            return res;
        }

        public List<Post> GetPostByName(string postName)
        {
            var res = Context.Posts.Where(p=>p.PostTitle == postName).ToList();
            return res;
        }

        public void UpdatePost(Post post)
        {
            if (post != null)
            {
                Context.Posts.Update(post);
                Context.SaveChanges();

            }

        }

        

        
    }
}
