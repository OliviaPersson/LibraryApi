using LibraryApi.Models;

namespace LibraryApi.Services
{
    public interface IJWTTokenService
    {
        Task<JWTToken> GenerateToken(User user);
    }
}
