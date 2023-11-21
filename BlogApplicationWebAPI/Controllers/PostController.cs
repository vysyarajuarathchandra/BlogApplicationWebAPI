using AutoMapper;
using BlogApplicationWebAPI.DTO;
using BlogApplicationWebAPI.Entitys;
using BlogApplicationWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using log4net;

namespace BlogApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService PostService;

        private readonly IMapper _mapper;
        private readonly ILogger<PostController>_logger;

        public PostController(IPostService postService, IMapper mapper , ILogger<UserController>_logger)
        {
            this.PostService = postService;
            _mapper = mapper;
            _logger = _logger;
        }

        [HttpGet, Route("GetAllPosts")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            try
            {
                List<Post> posts = PostService.GetPost();
                List<PostDTO> postsDTO = _mapper.Map<List<PostDTO>>(posts);
                return StatusCode(200, postsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet,Route("GetPostByTitle")]
        [AllowAnonymous]
        public IActionResult GetPost(string PostName) 
        {
            try
            {
                List<Post> posts = PostService.GetPostByName(PostName);
                List<PostDTO> postsDTO = _mapper.Map<List<PostDTO>>(posts);

                if (posts.Count > 0)
                    return StatusCode(200, postsDTO);
                else
                    return StatusCode(404, new JsonResult("No posts found with the specified title"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Route("AddPost")]
        [Authorize]
        public IActionResult Add([FromBody] PostDTO postDTO)
        {
            try
            {
                Post posts = _mapper.Map<Post>(postDTO);
                PostService.AddPost(posts);
                return StatusCode(200, posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut, Route("EditPost")]
        [Authorize(Roles ="User")]
        public IActionResult Edit(PostDTO postDTO)
        {
            try
            {
                Post post = _mapper.Map<Post>(postDTO);
                PostService.UpdatePost(post);
                return StatusCode(200, post);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Route("DeletePost/{postId}")]
        [Authorize]
        public IActionResult Delete(int postId)
        {
            try
            {
                PostService.DeletePost(postId);
                return StatusCode(200, new JsonResult($"Post with Id {postId} is Deleted"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
