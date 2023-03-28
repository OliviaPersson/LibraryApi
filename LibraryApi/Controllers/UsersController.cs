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

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _libraryService.GetUsersAsync();
            if (users == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No users in database.");
            }

            return StatusCode(StatusCodes.Status200OK, users);
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

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var dbUser = await _libraryService.AddUserAsync(user);

            if (dbUser == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{user.Id} could not be added.");
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            User dbUser = await _libraryService.UpdateUserAsync(user);

            if (dbUser == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{user.Id} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _libraryService.GetUserAsync(id);
            (bool status, string message) = await _libraryService.DeleteUserAsync(user);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, user);
        }
    }
}
