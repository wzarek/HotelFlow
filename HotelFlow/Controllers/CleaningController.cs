using HotelFlow.Models;
using HotelFlow.Models.DTO;
using HotelFlow.Services;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static HotelFlow.Helpers.Constants;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CleaningController: ControllerBase
    {
        private CleaningScheduleService _cleaningScheduleService { get; set; }
        private CleaningHistoryService _cleaningHistoryService { get; set; }

        public CleaningController(CleaningScheduleService cleaningScheduleService, CleaningHistoryService cleaningHistoryService)
        {
            _cleaningScheduleService = cleaningScheduleService;
            _cleaningHistoryService = cleaningHistoryService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("[action]")]
        public IActionResult All()
        {
            return Ok(_cleaningScheduleService.GetAllCleaningSchedules());
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("[action]/{employeeId}")]
        public IActionResult GetCleaningScheduleForEmployee(int employeeId)
        {
            if (employeeId < 1)
            {
                return BadRequest();
            }

            return Ok(_cleaningScheduleService.GetCleaningSchedulesByFilter(c => c.EmployeeId == employeeId));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        [Route("[action]")]
        public IActionResult Add(CleaningScheduleFromFrontEnd scheduleFD)
        {
            if (scheduleFD == null)
            {
                return BadRequest();
            }

            var scheduleDto = new CleaningScheduleDto
            {
                RoomId = scheduleFD.RoomId,
                EmployeeId = scheduleFD.EmployeeId,
                DateToBeCleaned = DateTime.ParseExact(scheduleFD.DateToBeCleaned, "yyyy-MM-dd", CultureInfo.InvariantCulture),
            };
            return Ok(_cleaningScheduleService.CreateCleaningSchedule(scheduleDto));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        [Route("[action]/{id}")]
        public IActionResult Edit(int id, CleaningScheduleDto scheduleDto)
        {
            if (id < 1 || scheduleDto == null)
            {
                return BadRequest();
            }

            return Ok(_cleaningScheduleService.UpdateCleaningSchedule(id, scheduleDto));
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var schedule = _cleaningScheduleService.GetCleaningScheduleById(id);

            if (schedule == null)
            {
                return NotFound();
            }

            _cleaningHistoryService.CreateCleaningHistory(new CleaningHistory { RoomId = schedule.RoomId, EmployeeId = schedule.EmployeeId });
            _cleaningScheduleService.DeleteCleaningSchedule(id);

            return Ok();
        }
    }
}
