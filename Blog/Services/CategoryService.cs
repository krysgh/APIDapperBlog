using Blog.API.Models;
using Blog.API.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.API.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryrepository)
        {
            _categoryRepository = categoryrepository;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

    }
}
