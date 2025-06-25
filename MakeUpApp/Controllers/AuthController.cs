using MakeUpApp.Models.DTOs.UserDTOS;
using MakeUpApp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MakeUpApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO user)
        {
            var result = await _authService.RegisterAsync(user);

            if (result.Succeeded)
            {
                return Ok("Registration successful");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
        {
            var token = await _authService.LoginAsync(user);

            if (token == null) return Unauthorized("Invalid Email or Password");

            return Ok(new {Token = token});
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UserUpdateDTO model)
        {
            // Optional: Get current user email from JWT
            model.Email = User.Identity?.Name ?? model.Email;

            var result = await _authService.UpdateUserAsync(model);

            if (result.Succeeded)
                return Ok("User updated");

            return BadRequest(result.Errors);
        }


    }
}
