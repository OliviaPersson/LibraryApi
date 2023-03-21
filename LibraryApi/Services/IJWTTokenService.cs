using LibraryApi.Entities.Models;

namespace LibraryApi.Services
{
    public interface IJWTTokenService
    {
        public JWTTokens Authenticate(User user);
    }
}
