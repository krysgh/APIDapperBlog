using Blog.API.Data;
using Blog.API.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class CategoryRepository
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var sql = "SELECT * FROM Category";
            var categories = new List<Category>();

            using (_connection)
            {
                await _connection.OpenAsync();
                var reader = await _connection.ExecuteReaderAsync(sql);

                while (reader.Read())
                {
                    var category = new Category(
                        reader["Name"].ToString(),
                        reader["Slug"].ToString());

                    categories.Add(category);
                }
                return categories;
            }
        }

    }
}
