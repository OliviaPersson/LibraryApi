using LibraryApi.DTOs;
using LibraryApi.Models;
using LibraryApi.Services.Auth;
using LibraryApi.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("signin")]
        public async Task<ActionResult<JWTToken>> SignIn(SignInDTO signInDTO)
        {
            var jwtToken = await _authService.Authenticate(signInDTO);

            if (jwtToken == null)
            {
                return Unauthorized();
            }

            return Ok(jwtToken);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            var user = await _userService.SignUpAsync(signUpDTO);

            if (user == null)
            {
                return BadRequest("Failed to sign up.");
            }

            return Ok("Sign up successful.");
        }
    }
}
