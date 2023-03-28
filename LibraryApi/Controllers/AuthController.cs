using LibraryApi.Entities.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly IJWTTokenService _jwttokenservice;

        public AuthController(ILibraryService libraryService, IJWTTokenService jwttokenservice)
        {
            _libraryService = libraryService;
            _jwttokenservice = jwttokenservice;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(User user)
        {
            User usr = await _libraryService.SignInAsync(user);

            if (usr != null)
            {
                var jwtToken = _jwttokenservice.Authenticate(usr);
                return StatusCode(StatusCodes.Status200OK, jwtToken);
            }
            return StatusCode(StatusCodes.Status204NoContent, $"No user found with email: {user.Email}");
        }
    }
}
