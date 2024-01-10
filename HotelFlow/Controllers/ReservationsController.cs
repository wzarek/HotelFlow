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
    [Route("[controller]")] // tj hotelflow.pl/reservations
    public class ReservationsController : ControllerBase
    {
        private ReservationService _reservationService { get; set; }

        public ReservationsController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult ViewReservation(int id)
        {
            return null; // pobiera info o rezerwacji
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditReservation(Reservation reservation)
        {
            return null; // edytowanie szczegolow rezerwacji
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult NewReservation(Reservation reservation)
        {
            return null; // dodanie nowej rezerwacji
        }

    }
}
