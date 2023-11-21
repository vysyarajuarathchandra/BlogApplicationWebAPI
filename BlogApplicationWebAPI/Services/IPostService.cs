using BlogApplicationWebAPI.Entitys;

namespace BlogApplicationWebAPI.Services
{
    public interface IPostService
    {
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int postId);
        Post GetPostById(int postId);
        List<Post> GetPost();
        List<Post> GetPostByName(string PostName);
    }
}
