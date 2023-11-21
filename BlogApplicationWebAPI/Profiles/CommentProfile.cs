using AutoMapper;
using BlogApplicationWebAPI.DTO;
using BlogApplicationWebAPI.Entitys;

namespace BlogApplicationWebAPI.Profiles
{
    public class CommentProfile :Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
        }

    }
}
