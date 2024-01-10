using HotelFlow.Models;
using HotelFlow.Models.DTO;
using HotelFlow.Services;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelFlow.Helpers.Constants;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("[controller]")] // tj hotelflow.pl/rooms
    public class RoomsController : ControllerBase
    {
        private RoomService _roomService { get; set; }

        public RoomsController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")] // + PRACOWNIK
        [Route("[action]")]
        public IActionResult RoomsList()
        {
            return null;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")] // + PRACOWNIK
        [Route("[action]")]
        public IActionResult RoomInfo(int id)
        {
            return null;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditRoom(Room room)
        {
            return null;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult DeleteRoom(Room room)
        {
            return null; // usuwanie pokoju
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult AddRoom(Room room)
        {
            return null; // dodawanie pokoju
        }

    }
}
