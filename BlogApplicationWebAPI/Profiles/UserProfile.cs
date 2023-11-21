using AutoMapper;
using BlogApplicationWebAPI.DTO;
using BlogApplicationWebAPI.Entitys;

namespace BlogApplicationWebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }

        
    }
}
