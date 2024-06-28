using BookingSystem.Application.Interfaces;
using BookingSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserEntity user)
        {
            _userService.Register(user);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserEntity user)
        {
            var token = _userService.Login(user);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}