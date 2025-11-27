using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;
using System.Data.Common;

namespace Blog.API.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task CreateUserAsync(UserRequestDTO user)
        {
            var newUser = new User(user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Name.ToLower().Replace(" ", "-"));
            await _userRepository.CreateUserAsync(newUser);

        }

        public async Task<UserResponseDTO> GetUserByIDAsync(int id)
        {
            return await _userRepository.GetUserByIDAsync(id);
        }

        public async Task UpdateUserByIDAsync(UserRequestDTO user, int id)
        {
            var newUser = new User(user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Name.ToLower().Replace(" ", "-"));
            await _userRepository.UpdateUserByIDAsync(newUser,id);
        }

        public async Task DeleteUserByIDAsync(int id)
        {
            await _userRepository.DeleteUserByIDAsync(id);
        }

        public async Task<List<UserRolesResponseDTO>> GetAllUsersRoles()
        {
            var users = await _userRepository.GetAllUserRoles();

            var dtos = users.Select(user => new UserRolesResponseDTO
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Bio = user.Bio,
                Image = user.Image,
                Slug = user.Slug,

                Roles = user.Roles.Select(role => new RoleResponseDTO
                {
                    Name = role.Name,
                    Slug = role.Slug
                }).ToList()
            }).ToList();

            return dtos;
        }

        public async Task<UserRolesResponseDTO> GetUserRolesByID(int id)
        {
            var user = await _userRepository.GetUserRolesByID(id);

            if (user == null)
            {
                return null;
            }

            var dto = new UserRolesResponseDTO
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Bio = user.Bio,
                Image = user.Image,
                Slug = user.Slug,

                Roles = user.Roles?.Select(role => new RoleResponseDTO
                {
                    Name = role.Name,
                    Slug = role.Slug
                }).ToList()
            };
            return dto;
        }

    }
}
