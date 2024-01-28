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
    [Route("[controller]")]
    public class ReservationsController : ControllerBase
    {
        private ReservationService _reservationService { get; set; }
        private ReservationStatusService _reservationStatusService { get; set; }
        private ReviewService _reviewService { get; set; }

        public ReservationsController(ReservationService reservationService, ReservationStatusService reservationStatusService, ReviewService reviewService)
        {
            _reservationService = reservationService;
            _reservationStatusService = reservationStatusService;
            _reviewService = reviewService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        [Route("[action]")]
        public IActionResult All()
        {
            return Ok(_reservationService.GetAllReservations());
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

            return Ok(_reservationService.GetTopNReservationsWithOffset(offset));
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("{id}")]
        public IActionResult GetReservationById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var reservation = _reservationService.GetReservationById(id);

            if (reservation == null) 
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult Edit(int id, ReservationDataDto reservationDto)
        {
            if (id < 1 || reservationDto == null)
            {
                return BadRequest();
            }

            _reservationService.UpdateReservation(id, reservationDto);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        [Route("[action]")]
        public IActionResult EditStatus(int reservationId, int statusId)
        {
            if (reservationId < 1 || statusId < 1)
            {
                return BadRequest();
            }

            _reservationService.EditStatus(reservationId, statusId);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "User,Employee,Admin")]
        [Route("[action]")]
        public IActionResult Add(ReservationDataDto reservationDto)
        {
            if (reservationDto == null)
            {
                return BadRequest();
            }

            return Ok(_reservationService.CreateReservation(reservationDto)); 
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        [Route("[controller]/{id}")]
        public IActionResult GetReservationForReview(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var review = _reviewService.GetReviewById(id);

            if (review == null)
            {
                return NotFound();
            }

            var reservation = _reservationService.GetReservationsByFilter(r => r.Id == review.ReservationId).FirstOrDefault();

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }
    }
}
