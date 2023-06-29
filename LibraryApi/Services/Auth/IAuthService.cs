using LibraryApi.DTOs;
using LibraryApi.Models;

namespace LibraryApi.Services.Auth
{
    public interface IAuthService
    {
        Task<JWTToken> Authenticate(SignInDTO signInDTO);
    }
}
