using CryptoVue.Authentication;
using CryptoVue.Data.Models;
using CryptoVue.Services;
using CryptoVue.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVue.Controllers
{
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

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            var user = _userService.GetUser(model.Email);

            if (user is not null && _userService.IsAuthenticated(model.Password, user!.PasswordHash))
            {
                var token = _jwtService.GenerateToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
