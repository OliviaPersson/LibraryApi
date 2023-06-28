using LibraryApi.DTOs;
using LibraryApi.Models;

namespace LibraryApi.Services
{
    public interface IAuthService
    {
        Task<JWTToken> Authenticate(SignInDTO signInDTO);
    }
}
