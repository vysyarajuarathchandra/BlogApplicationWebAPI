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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService CommentService;

        private readonly IMapper _mapper;
        private readonly ILogger <CommentController>_logger;

        public CommentController(ICommentService commentService, IMapper mapper, ILogger<CommentController> _logger)
        {
            CommentService = commentService;
            _mapper = mapper;
            _logger = _logger;
        }
        [HttpGet, Route("GetAllComments")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            try
            {
                List<Comment> comments = CommentService.GetComment();
                List<CommentDTO> commentsDTO = _mapper.Map<List<CommentDTO>>(comments);
                return StatusCode(200, commentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

      

        [HttpPost, Route("AddComment")]
        [Authorize]
        public IActionResult Add([FromBody] CommentDTO commentDTO)
        {
            try
            {
                Comment comment = _mapper.Map<Comment>(commentDTO);
                CommentService.AddComment(comment);
                return StatusCode(200, comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut, Route("UpdateComment")]
        [Authorize]
        public IActionResult Update(CommentDTO commentDTO)
        {
            try
            {
                Comment comment = _mapper.Map<Comment>(commentDTO);
                CommentService.UpdateComment(comment);
                return StatusCode(200, comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Route("DeleteComment/{commentId}")]
        [Authorize]
        public IActionResult Delete(int commentId)
        {
            try
            {
                CommentService.DeleteComment(commentId);
                return StatusCode(200, new JsonResult($"Comment with Id {commentId} is Deleted"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);

            }

        }
    }
}
