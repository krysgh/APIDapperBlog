using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task CreatePostAsync(Post post, int tagID);

        Task<List<Post>> GetAllPostsAsync();

        Task<Post> GetPostByIDAsync(int id);

        Task<List<Post>> GetPostsByCategoryIDAsync(int id);

        Task<List<Post>> GetPostsByUserIDAsync(int id);

        Task<List<Post>> GetPostsByTagIDAsync(int id);

        Task UpdatePostByIDAsync(Post post, int id);

        Task DeletePostByIDAsync(int id);

    }
}
