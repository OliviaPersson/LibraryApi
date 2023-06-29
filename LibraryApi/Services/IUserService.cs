using LibraryApi.DTOs;
using LibraryApi.Models;

namespace LibraryApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(Guid id);
        Task<User> SignUpAsync(SignUpDTO signUpDTO);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(Guid id);
    }
}
