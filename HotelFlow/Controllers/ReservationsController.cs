using HotelFlow.Models;
using HotelFlow.Models.DTO;
using HotelFlow.Services;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HotelFlow.Helpers.Constants;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IActionResult Edit(Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest();
            }

            _reservationService.UpdateReservation(reservation);

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

            var reservation = _reservationService.GetReservationById(reservationId);
            var reservationStatus = _reservationStatusService.GetReservationStatusById(statusId);

            if (reservation == null || reservationStatus == null)
            {
                return NotFound();
            }

            reservation.StatusId = statusId;

            _reservationService.UpdateReservation(reservation);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "User,Employee,Admin")]
        [Route("[action]")]
        public IActionResult Add(Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest();
            }

            return Ok(_reservationService.CreateReservation(reservation)); 
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        [Route("[action]/{id}")]
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

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("[action]")]
        public IActionResult GetCurrentUserReservations()
        {
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            if (userIdString == string.Empty)
            {
                return BadRequest();
            }

            int userId = int.Parse(userIdString);

            var reviews = _reservationService.GetReservationsByFilter(r => r.CustomerId == userId).ToList();

            if (reviews == null || !reviews.Any())
            {
                return Ok(new List<Review>());
            }

            return Ok(reviews);
        }
    }
}
