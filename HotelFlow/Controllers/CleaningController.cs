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
    [Route("[controller]")] // tj hotelflow.pl/cleaning
    public class CleaningController: ControllerBase
    {
        private CleaningScheduleService _cleaningScheduleService { get; set; }
        private CleaningHistoryService _cleaningHistoryService { get; set; }

        public CleaningController(CleaningScheduleService cleaningScheduleService, CleaningHistoryService cleaningHistoryService)
        {
            _cleaningScheduleService = cleaningScheduleService;
            _cleaningHistoryService = cleaningHistoryService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult AddCleaningUnit(CleaningSchedule unit)
        {
            return null; // dodaje sprzatanie (dzien, pokoj, id pracownika (????) )
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditCleaningUnit(CleaningSchedule unit)
        {
            return null;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult LoadCleaningHistory()
        {
            return null;
        }

    }
}
