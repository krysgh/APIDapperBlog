using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface IPostService
    {

        Task<PostResponseDTO> GetPostByIDAsync(int id);

        Task DeletePostByIDAsync(int id);
    }
}
