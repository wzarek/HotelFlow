using HotelFlow.Helpers;
using HotelFlow.Models.DTO;
using HotelFlow.Models.FormModels;
using HotelFlow.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserAuthService _userManager;

        private readonly IConfiguration _configuration;
        public RegisterController(UserAuthService userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = model.UserName,
                EmailAddress = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                DateCreated = DateTime.Now,
                IsActive = true,
                RoleId = (int)Constants.Roles.User,
            };

            var result = await _userManager.CreateUserAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "User registered successfully" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
            return BadRequest(ModelState);
        }
    }
}
