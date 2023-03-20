using LibraryApi.Entities.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignInController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public SignInController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(User user)
        {

            User usr = await _libraryService.SignInAsync(user);

            if (usr == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No user found with email: {user.Email}");
            }

            return StatusCode(StatusCodes.Status200OK, usr);
        }
    }
}
