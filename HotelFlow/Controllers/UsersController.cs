using HotelFlow.Helpers;
using HotelFlow.Models.DTO;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelFlow.Helpers.Constants;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UserService _userService { get; set; }

        public UsersController(UserService userService) 
        { 
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult All(bool getInactive = false)
        {
            return Ok(_userService.GetAllUsers(getInactive));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{offset}")]
        public IActionResult GetWithOffset(int offset)
        {
            if (offset < 0)
            {
                return BadRequest(OffsetWrongExceptionMessage);
            }

            return Ok(_userService.GetTopNUsersWithOffset(offset));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult GetUserById(int id)
        {
            if (id < 1)
            {
                return BadRequest(string.Format(UserNotFoundExceptionMessage, $"id: {id}"));
            }

            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return BadRequest(string.Format(UserNotFoundExceptionMessage, $"id: {id}"));
            }

            return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult GetByRole(int roleId)
        {
            if (roleId < 1 || roleId > 4)
            {
                return BadRequest(RoleWrongExceptionMessage);
            }

            return Ok(
                new 
                {
                    role = ((Roles)roleId).GetDescription(), 
                    users = _userService.GetUsersByFilter(u => u.RoleId == roleId)
                }
            );
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id}")]
        public IActionResult Edit(int id, UserDataDto userDto)
        {
            if (id < 1 || userDto == null)
            {
                return BadRequest();
            }

            return Ok(_userService.UpdateUser(id, userDto));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditMultiple(IEnumerable<User> users)
        {
            if (users == null || !users.Any())
            {
                return BadRequest();
            }

            _userService.UpdateUsers(users);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult Delete(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userService.DeleteUser(user.Id);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            _userService.DeleteUser(id);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult DeleteMultipleByIds(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return BadRequest();
            }

            _userService.DeleteUsers(ids);
            return Ok();
        }
    }
}
