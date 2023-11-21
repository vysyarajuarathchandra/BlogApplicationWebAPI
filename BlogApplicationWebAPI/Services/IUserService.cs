using BlogApplicationWebAPI.Entitys;

namespace BlogApplicationWebAPI.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        List<User> GetUsers();
        User GetUserById(int UserId);
        List<User>  GetUserByRoleName(string Role);
        void UpdateUser(User user);
        void DeleteUser(int UserId);
        User ValidteUser(string email, string password);
    }
}
