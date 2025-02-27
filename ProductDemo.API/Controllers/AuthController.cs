using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductDemo.Domain.Entities;

namespace ProductDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly SignInManager<AspNetUser> _signInManager;
        private readonly UserManager<AspNetUser> _userManager;

        public AuthController(SignInManager<AspNetUser> signInManager, UserManager<AspNetUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });
            var passwordHasher = new PasswordHasher<AspNetUser>();

            //string? originalPassword = Umbraco7PasswordHelper.ExtractPassword("AQAAAAIAAYagAAAAEDPGzr3nhzvOOfnTHM7z6vHNtm9AfySsoLBRylPOHsi8cFundQc90ixUJLXn7qOUTw==");
            //if (!string.IsNullOrEmpty(originalPassword))
            //{
            //    user.PasswordHash = passwordHasher.HashPassword(user, originalPassword);
            //}

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
                return Unauthorized(new { message = "Invalid username or password" });

            return Ok(new { message = "Login successful" });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
 
