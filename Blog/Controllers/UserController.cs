using Blog.API.Controllers.Interfaces;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsersAsync()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUserAsync(UserRequestDTO user)
        {
            await _userService.CreateUserAsync(user);

            return Created();
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetUserByIDAsync(int id)
        {
            return Ok(await _userService.GetUserByIDAsync(id));
        }

        [HttpPut("UpdateByID/{id}")]
        public async Task<ActionResult> UpdateUserByIDAsync(UserRequestDTO user, int id)
        {
            var userFound = await _userService.GetUserByIDAsync(id);

            if(userFound is null)
            {
                return NotFound();
            }
            await _userService.UpdateUserByIDAsync(user, id);
            return Ok();
        }


        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult> DeleteUserByIDAsync(int id)
        {
            var userFound = await _userService.GetUserByIDAsync(id);

            if (userFound is null)
            {
                return NotFound();
            }
            await _userService.DeleteUserByIDAsync(id);
            return Ok();
        }

        [HttpGet("GetUsersRoles")]
        public async Task<ActionResult<List<UserRolesResponseDTO>>> GetUsersRoles()
        {
            var users = await _userService.GetAllUsersRoles();
            return Ok(users);
        }

        [HttpGet("GetUserRolesByID/{id}")]
        public async Task<ActionResult<UserRolesResponseDTO>> GetUserRolesByID(int id)
        {
            var user = await _userService.GetUserRolesByID(id);
            return Ok(user);
        }
    }
}
