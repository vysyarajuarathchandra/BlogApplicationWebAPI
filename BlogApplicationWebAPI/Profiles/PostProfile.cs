using AutoMapper;
using BlogApplicationWebAPI.DTO;
using BlogApplicationWebAPI.Entitys;

namespace BlogApplicationWebAPI.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();
        }

    }
}
