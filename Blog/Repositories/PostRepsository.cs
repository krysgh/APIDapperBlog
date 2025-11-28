using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class PostRepsository : IPostRepository
    {

        private static readonly string INSERTPOST = @"INSERT INTO Post(CategoryId,AuthorId,Title,Summary,Body,Slug,CreateDate,LastUpdateDate) 
                                                                  VALUES (@CategoryID,@AuthorID,@Title,@Summary,@Body,@Slug,@CreateDate,@LastUpdateDate);
                                                      SELECT SCOPE_IDENTITY;";

        private static readonly string INSERTPOSTTAG = "INSERT INTO PostTag VALUES (@PostId,@TagId);";

        private static readonly string SELECTALLPOSTS = @"SELECT p.Id,p.CategoryId,p.AuthorId,p.Title,p.Body,p.Slug,p.CreateDate,p.LastUpdateDate,
                                                     	    c.Name,c.Slug,
                                                     	    u.Name,u.Email,u.PasswordHash,u.Bio,u.Image,u.Slug,
                                                     	    t.Name,t.Slug
                                                     FROM [Post] p
                                                     LEFT JOIN [Category] c ON p.CategoryId = c.Id
                                                     LEFT JOIN [User] u ON p.AuthorId = u.Id
                                                     LEFT JOIN [PostTag] pt ON p.Id = pt.PostId
                                                     LEFT JOIN [Tag] t ON pt.TagId = t.Id;";
        private static readonly string SELECTPOSTBYID= @"SELECT p.Id,p.CategoryId,p.AuthorId,p.Title,p.Body,p.Slug,p.CreateDate,p.LastUpdateDate,
                                                     	    c.Name,c.Slug,
                                                     	    u.Name,u.Email,u.PasswordHash,u.Bio,u.Image,u.Slug,
                                                     	    t.Name,t.Slug
                                                     FROM [Post] p
                                                     LEFT JOIN [Category] c ON p.CategoryId = c.Id
                                                     LEFT JOIN [User] u ON p.AuthorId = u.Id
                                                     LEFT JOIN [PostTag] pt ON p.Id = pt.PostId
                                                     LEFT JOIN [Tag] t ON pt.TagId = t.Id
                                                     WHERE p.Id = @PostId;";
        private static readonly string SELECTPOSTBYCATEGORYID = @"SELECT p.Id,p.CategoryId,p.AuthorId,p.Title,p.Body,p.Slug,p.CreateDate,p.LastUpdateDate,
                                                     	    c.Name,c.Slug,
                                                     	    u.Name,u.Email,u.PasswordHash,u.Bio,u.Image,u.Slug,
                                                     	    t.Name,t.Slug
                                                     FROM [Post] p
                                                     LEFT JOIN [Category] c ON p.CategoryId = c.Id
                                                     LEFT JOIN [User] u ON p.AuthorId = u.Id
                                                     LEFT JOIN [PostTag] pt ON p.Id = pt.PostId
                                                     LEFT JOIN [Tag] t ON pt.TagId = t.Id
                                                     WHERE c.Id = @CategoryId;";
        private static readonly string SELECTPOSTBYUSERID = @"SELECT p.Id,p.CategoryId,p.AuthorId,p.Title,p.Body,p.Slug,p.CreateDate,p.LastUpdateDate,
                                                     	    c.Name,c.Slug,
                                                     	    u.Name,u.Email,u.PasswordHash,u.Bio,u.Image,u.Slug,
                                                     	    t.Name,t.Slug
                                                     FROM [Post] p
                                                     LEFT JOIN [Category] c ON p.CategoryId = c.Id
                                                     LEFT JOIN [User] u ON p.AuthorId = u.Id
                                                     LEFT JOIN [PostTag] pt ON p.Id = pt.PostId
                                                     LEFT JOIN [Tag] t ON pt.TagId = t.Id
                                                     WHERE u.Id = @UserId;";
        private static readonly string SELECTPOSTBYTAGID = @"SELECT p.Id,p.CategoryId,p.AuthorId,p.Title,p.Body,p.Slug,p.CreateDate,p.LastUpdateDate,
                                                     	    c.Name,c.Slug,
                                                     	    u.Name,u.Email,u.PasswordHash,u.Bio,u.Image,u.Slug,
                                                     	    t.Name,t.Slug
                                                     FROM [Post] p
                                                     LEFT JOIN [Category] c ON p.CategoryId = c.Id
                                                     LEFT JOIN [User] u ON p.AuthorId = u.Id
                                                     LEFT JOIN [PostTag] pt ON p.Id = pt.PostId
                                                     LEFT JOIN [Tag] t ON pt.TagId = t.Id
                                                     WHERE t.Id = @TagId;";
        private static readonly string UPDATEPOST= @"UPDATE Post
                                                     SET CategoryId = @CategoryId,
                                                         AuthorId = @AuthorId,
                                                     	 Title = @Title,
                                                     	 Body = @Body,
                                                     	 Slug = @Slug,
                                                     	 CreateDate = @CreateDate,
                                                     	 LastUpdateDate = @LastUpdateDate
                                                     WHERE Id = @PostId;";
        private static readonly string DELETEPOST= @"DELETE FROM PostTag
                                                     WHERE PostId = @PostId;
                                                     
                                                     DELETE FROM Post
                                                     WHERE Id = @PostId";

        private SqlConnection _connection;

        public PostRepsository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task CreatePostAsync(Post post, int tagID)
        {

        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return null;
        }

        public async Task<Post> GetPostByIDAsync(int id)
        {
            return (await _connection.QueryFirstOrDefaultAsync<Post>(SELECTPOSTBYID, new { PostId = id })); //erro aqui
        }

        public async Task<List<Post>> GetPostsByCategoryIDAsync(int id)
        {
            return null;
        }

        public async Task<List<Post>> GetPostsByUserIDAsync(int id)
        {
            return null;
        }

        public async Task<List<Post>> GetPostsByTagIDAsync(int id)
        {
            return null;
        }


        public async Task UpdatePostByIDAsync(Post post, int id)
        {

        }

        public async Task DeletePostByIDAsync(int id)
        {
            await _connection.ExecuteAsync(DELETEPOST, new { PostId = id });
        }
    }
}
