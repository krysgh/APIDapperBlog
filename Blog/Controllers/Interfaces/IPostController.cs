using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface IPostController
    {
        ActionResult HeartBeat();

        Task<ActionResult<PostResponseDTO>> GetPostByIDAsync(int id);

        Task<ActionResult> DeletePostByIDAsync(int id);
    }
}
