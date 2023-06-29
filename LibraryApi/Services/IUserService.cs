using LibraryApi.DTOs;
using LibraryApi.Models;

namespace LibraryApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserAsync(Guid id);
        Task<User> SignUpAsync(SignUpDTO signUpDTO);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(Guid id);
    }
}
