using Vet_CIMAGT.Core.DTOs;

namespace Vet_CIMAGT.Service.Service.Interface
{
    public interface IUserService
    {
        Task<List<UserDTOs>> GetAllUsersAsync();
        Task<UserDTOs> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(UserCreateDTO userDTO);
        Task UpdateUserAsync(UserUpdateDTO userDTO);
        Task DeleteUserAsync(Guid id);
        Task<string> LoginAsync(LoginDTO loginDTO);
    }
}

