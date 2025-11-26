using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Services;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Blog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Category>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);

        }

        [HttpPost("Create")]
        public ActionResult CreateCategory(Category category)
        {
            return Ok();
        }


    }
}
