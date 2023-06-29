using LibraryApi.Models;

namespace LibraryApi.Services.JWTTokens
{
    public interface IJWTTokenService
    {
        Task<JWTToken> GenerateToken(User user);
    }
}
