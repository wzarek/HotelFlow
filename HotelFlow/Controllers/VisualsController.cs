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
    [Route("[controller]")] // tj hotelflow.pl/visuals
    public class VisualsController : ControllerBase
    {
        private FloorSchemaService _floorSchemaService { get; set; }

        public VisualsController(FloorSchemaService floorSchemaService)
        {
            _floorSchemaService = floorSchemaService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult ShowFloor(int floor)
        {
            return null; // pobiera info o pietrze
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditFloor(FloorSchema floor)
        {
            return null; // zmienia wymiary pietra
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditObjectPlacement(ObjectPlacement _object)
        {
            return null; // zmienia parametry obiektu na siatce
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult DeleteObject(ObjectPlacement _object)
        {
            return null; // usuwanie obiektu
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult AddObject(ObjectPlacement _object)
        {
            return null; // dodawanie obiektu
        }


    }
}
