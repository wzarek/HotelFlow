using HotelFlow.Models.DTO;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelFlow.Helpers.Constants;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("[controller]")] // tj hotelflow.pl/users
    public class UsersController : ControllerBase
    {
        private UserService _userService { get; set; }

        public UsersController(UserService userService) 
        { 
            _userService = userService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")] // tj hotelflow.pl/users/all
        public IActionResult All()
        {
            return null; // tu bedzie logika pobierania wszystkich userow
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")] // tj hotelflow.pl/users/all
        public IActionResult All(int offset)
        {
            return null; // tu bedzie logika pobierania wszystkich userow z offsetem (tj pobieramy np co 10)
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("{id}")] // tj. np. hotelflow.pl/users/6
        public IActionResult GetUserById(int id)
        {
            return null; // tu bedzie logika pobierania usera przez id
        }

        [HttpGet]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")] // tj. np. hotelflow.pl/users/employees
        public IActionResult Employees()
        {
            return null; // tu bedzie logika pobierania pracownikow
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")] // tj. np. hotelflow.pl/users/edit
        public IActionResult Edit(User user)
        {
            return null; // tu bedzie logika edycji
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")] // tj. np. hotelflow.pl/users/edit
        public IActionResult Edit(List<User> user)
        {
            return null; // tu bedzie logika edycji wielu
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")] // tj. np. hotelflow.pl/users/delete
        public IActionResult Delete(User user)
        {
            return null; // tu bedzie logika usuwania
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")] // tj. np. hotelflow.pl/users/delete
        public IActionResult Delete(List<User> user)
        {
            return null; // tu bedzie logika usuwania wielu
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id}")] // tj. np. hotelflow.pl/users/delete/6
        public IActionResult Delete(int id)
        {
            return null; // tu bedzie logika usuwania po id
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")] // tj. np. hotelflow.pl/users/delete
        public IActionResult Delete(List<int> ids)
        {
            return null; // tu bedzie logika usuwania wielu po id
        }
    }
}
