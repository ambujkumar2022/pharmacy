using Microsoft.AspNetCore.Mvc;
using pharmacy.Models;
using pharmacy.Services;

namespace pharmacy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService = new();

        [HttpPost("register")]
        public IActionResult Register(Users user)
        {
            var users = _userService.GetAll();

            if(users.Any(u => u.UserName == user.UserName))
            {
                return BadRequest("Username already exists.");
            }

            user.Id = users.Count + 1;
            users.Add(user);
            _userService.SaveAll(users);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login(Users user)
        {
            var users = _userService.GetAll();
            var existingUser = users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            if (existingUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok("User logged in successfully.");
        }
    }
}
