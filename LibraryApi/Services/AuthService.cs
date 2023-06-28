using LibraryApi.DTOs;
using LibraryApi.Models;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JWTTokenService _jwtTokenService;

        public AuthService(IUserRepository userRepository, JWTTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<JWTToken> Authenticate(SignInDTO signInDTO)
        {
            User user = await _userRepository.GetUserByEmailAsync(signInDTO.Email);

            if (user == null || user.Password != signInDTO.Password)
            {
                return null;
            }

            return await _jwtTokenService.GenerateToken(user);
        }
    }
}
