using LibraryApi.DTOs;
using LibraryApi.Models;
using LibraryApi.Repositories;
using LibraryApi.Services.JWTTokens;

namespace LibraryApi.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTTokenService _jwtTokenService;

        public AuthService(IUserRepository userRepository, IJWTTokenService jwtTokenService)
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
