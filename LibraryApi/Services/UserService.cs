using LibraryApi.DTOs;
using LibraryApi.Models;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            IEnumerable<UserDto> users = (await _userRepository.GetUsersAsync()).Select(user => MapUserToDto(user)).ToList();
            return users;
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return MapUserToDto(user);
        }
        public async Task<User> SignUpAsync(SignUpDTO signUpDTO)
        {
            var user = new User
            {
                FirstName = signUpDTO.FirstName,
                LastName = signUpDTO.LastName,
                UserName = signUpDTO.UserName,
                Email = signUpDTO.Email,
                Password = signUpDTO.Password,
            };

            return await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = MapDtoToUser(userDto);
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteUserAsync(user);
            }
        }

        public UserDto MapUserToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password
            };
        }

        public User MapDtoToUser(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }
    }
}
