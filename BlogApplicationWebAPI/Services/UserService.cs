using BlogApplicationWebAPI.Database;
using BlogApplicationWebAPI.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BlogApplicationWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly BlogContext Context = null;

        public UserService (BlogContext context)
        {
            Context = context;  
        }
        public void  AddUser(User user)
        {
            try
            {
                Context.Users.Add(user);
                Context.SaveChanges();
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void  DeleteUser(int userId)
        {
            try
            {
                User user = Context.Users.SingleOrDefault(u=>u.UserId==userId);
                if (user != null)
                {
                    Context.Users.Remove(user);
                    Context.SaveChanges();
                    
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public User GetUserById(int userId)
        {
            try
            {
                var res = Context.Users.SingleOrDefault(u=>u.UserId==userId);

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> GetUserByRoleName(string Role)
        {
           var res=Context.Users.Where(u=>u.Role==Role).ToList();
            return res; 
        }

        public List<User> GetUsers()
        {
            try
            {
                return Context.Users.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void  UpdateUser(User user)
        {

            try
            {

                if (user != null)
                {
                    Context.Users.Update(user);
                    Context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public User ValidteUser(string email, string password)
        {
            return Context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
