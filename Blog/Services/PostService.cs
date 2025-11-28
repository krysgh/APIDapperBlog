using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostResponseDTO> GetPostByIDAsync(int id)
        {
            var post = await _postRepository.GetPostByIDAsync(id);

            if (post == null)
            {
                return null;
            }

            var dto = new PostResponseDTO
            {
                Title = post.Title,
                Summary = post.Summary,
                Body = post.Body,
                Slug = post.Slug,
                CreateDate = post.CreateDate,
                LastUpdateDate = post.LastUpdateDate,
                UserName = post.User.Name,
                CategoryName = post.Category.Name,

                TagNames = post.Tags?.Select(tag => new TagResponseDTO
                {
                    Name = tag.Name,
                    Slug = tag.Slug
                }).ToList()
            };
            return dto;
        } 

        public async Task DeletePostByIDAsync(int id)
        {
            await _postRepository.DeletePostByIDAsync(id);
        }


    }
    
}
