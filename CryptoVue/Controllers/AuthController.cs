using CryptoVue.Data.Models;
using CryptoVue.Services;
using CryptoVue.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVue.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService userService, IJwtService jwtService)
        {
            this._userService = userService;
            this._jwtService = jwtService;
        }
        [HttpPost("token")]
        public IActionResult GetToken(string email, string password)
        {
            var storedUser = _userService.GetUser(email);
            if (!_userService.IsAuthenticated(password, storedUser.PasswordHash))
            {
                return Unauthorized();
            }

            var tokenString = _jwtService.GenerateToken(storedUser);
            return Ok(new { token = tokenString });
        }
    }
}
