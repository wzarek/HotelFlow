using HotelFlow.Helpers;
using HotelFlow.Models.FormModels;
using HotelFlow.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserAuthService _userManager;
        private readonly IConfiguration _configuration;
        public LoginController(UserAuthService userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Index(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userManager.ValidateCredentials(model.Email, model.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var secret = _configuration["JwtSettings:SecretKey"];
            var token = TokenManager.GenerateJwtToken(user, secret);

            return Ok(new { token });
        }
    }
}
