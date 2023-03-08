using LibraryApi.Entities.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public UsersController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            User user = await _libraryService.GetUserAsync(id);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No user found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, user);
        }
    }
}
