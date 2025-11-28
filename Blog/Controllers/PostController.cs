using Blog.API.Controllers.Interfaces;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase, IPostController
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetPostByID/{id}")]
        public async Task<ActionResult<PostResponseDTO>> GetPostByIDAsync(int id)
        {
            var post = await _postService.GetPostByIDAsync(id);
            return Ok(post);
        }

        [HttpDelete("DeletePostByID/{id}")]
        public async Task<ActionResult> DeletePostByIDAsync(int id)
        {
            await _postService.DeletePostByIDAsync(id);
            return Ok();
        }

    }
}
