using HotelFlow.Helpers;
using HotelFlow.Models;
using HotelFlow.Models.DTO;
using HotelFlow.Services;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
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
        private RoomService _roomService { get; set; }
        private UserService _userService { get; set; }

        public ReservationsController(ReservationService reservationService, ReservationStatusService reservationStatusService, ReviewService reviewService, UserService userService, RoomService roomService)
        {
            _reservationService = reservationService;
            _reservationStatusService = reservationStatusService;
            _reviewService = reviewService;
            _userService = userService;
            _roomService = roomService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        [Route("[action]")]
        public IActionResult All()
        {
            var reservations = _reservationService.GetAllReservations();

            var reservationsToReturn = new List<ReservationDataToSend>();

            if (reservations == null || !reservations.Any())
            {
                return Ok(reservationsToReturn);
            }

            foreach (var reservation in reservations)
            {
                reservationsToReturn.Add(
                    new ReservationDataToSend
                    {
                        Id = reservation.Id,
                        ReservationNumber = $"{reservation.Id}{reservation.RoomId}",
                        RoomId = reservation.RoomId,
                        DateFrom = reservation.DateFrom.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                        DateTo = reservation.DateTo.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Status = ((ReservationStatuses)reservation.StatusId).GetDescription(),
                        DateCreated = reservation.DateCreated.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                        TotalPrice = reservation.TotalPrice
                    }
                );
            }
            return Ok(reservationsToReturn);
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
        public IActionResult Edit(int id, ReservationDto reservationDto)
        {
            if (id < 1 || reservationDto == null)
            {
                return BadRequest();
            }

            _reservationService.UpdateReservation(id, reservationDto);

            return Ok();
        }

        public class ReservationEditStatus
        {
            public int reservationId { get; set; }
            public int statusId { get; set; }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        [Route("[action]")]
        public IActionResult EditStatus(ReservationEditStatus status)
        {
            if (status.reservationId < 1 || status.statusId < 1)
            {
                return BadRequest();
            }

            var reservationData = _reservationService.EditStatus(status.reservationId, status.statusId);

            var reservationToSend = new ReservationDataToSend
            {
                Id = reservationData.Id,
                ReservationNumber = $"{reservationData.Id}{reservationData.RoomId}",
                RoomId = reservationData.RoomId,
                DateFrom = reservationData.DateFrom.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                DateTo = reservationData.DateTo.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                Status = ((ReservationStatuses)reservationData.StatusId).GetDescription(),
                DateCreated = reservationData.DateCreated.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)
            };

            return Ok(reservationToSend);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("[action]/{reservationId}")]
        public IActionResult Cancel(int reservationId)
        {
            if (reservationId < 1)
            {
                return BadRequest();
            }

            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            if (userIdString == string.Empty)
            {
                return BadRequest();
            }

            int userId = int.Parse(userIdString);

            var reservationCheck = _reservationService.GetReservationsByFilter(r => r.Id == reservationId && r.CustomerId == userId).ToList();

            if (!reservationCheck.Any())
            {
                return BadRequest();
            }

            var reservationData = _reservationService.EditStatus(reservationId, (int)ReservationStatuses.Closed);

            var reservationToSend = new ReservationDataToSend
            {
                Id = reservationData.Id,
                ReservationNumber = $"{reservationData.Id}{reservationData.RoomId}",
                RoomId = reservationData.RoomId,
                DateFrom = reservationData.DateFrom.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                DateTo = reservationData.DateTo.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                Status = ((ReservationStatuses)reservationData.StatusId).GetDescription(),
                DateCreated = reservationData.DateCreated.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)
            };

            return Ok(reservationToSend);
        }

        [HttpPost]
        [Authorize(Roles = "User,Employee,Admin")]
        [Route("[action]")]
        public IActionResult Add(ReservationFromFrontend reservationFromFrontend)
        {
            if (reservationFromFrontend == null)
            {
                return BadRequest();
            }

            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            if (userIdString == string.Empty)
            {
                return BadRequest();
            }

            int userId = int.Parse(userIdString);

            var room = _roomService.GetRoomById(reservationFromFrontend.RoomId);

            if (room == null)
            {
                return BadRequest();
            }

            var reservationDto = new ReservationDto
            {
                CustomerId = reservationFromFrontend.CustomerId,
                EmployeeId = reservationFromFrontend.EmployeeId,
                StatusId = reservationFromFrontend.StatusId,
                RoomId = reservationFromFrontend.RoomId,
                DateFrom = DateTime.ParseExact(reservationFromFrontend.DateFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                DateTo = DateTime.ParseExact(reservationFromFrontend.DateTo, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                TotalPrice = room.Price
            };

            var reservationCheck = _reservationService.GetReservationsByFilter(
                    res => (res.RoomId == reservationDto.RoomId)
                    && (res.DateFrom <= reservationDto.DateFrom && res.DateTo > reservationDto.DateFrom)
                            || (res.DateFrom < reservationDto.DateTo && res.DateTo > reservationDto.DateTo)
                    && res.StatusId != (int)ReservationStatuses.Closed
                ).ToList();

            if (reservationCheck.Any())
            {
                return BadRequest();
            }

            if (reservationDto.CustomerId == 0)
            {
                reservationDto.CustomerId = userId;
                reservationDto.EmployeeId = _userService.GetUsersByFilter(u => u.RoleId == (int)Roles.Admin).First().Id;
            } else if (reservationDto.EmployeeId == 0)
            {
                reservationDto.EmployeeId = userId;
            }

            reservationDto.StatusId = (int)ReservationStatuses.ToConfirm;

            var createdReservation = _reservationService.CreateReservation(reservationDto);

            var createdReservationToSend = new ReservationDataToSend
            {
                Id = createdReservation.Id,
                ReservationNumber = $"{createdReservation.Id}{createdReservation.RoomId}",
                RoomId = createdReservation.RoomId,
                DateFrom = createdReservation.DateFrom.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                DateTo = createdReservation.DateTo.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                Status = ((ReservationStatuses)createdReservation.StatusId).GetDescription(),
                DateCreated = createdReservation.DateCreated.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                TotalPrice = createdReservation.TotalPrice
            };

            return Ok(createdReservationToSend); 
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

            var reservations = _reservationService.GetReservationsByFilter(r => r.CustomerId == userId).ToList();

            var reservationsToReturn = new List<ReservationDataToSend>();

            if (reservations == null || !reservations.Any())
            {
                return Ok(reservationsToReturn);
            }

            foreach ( var reservation in reservations)
            {
                reservationsToReturn.Add(
                    new ReservationDataToSend
                    {
                        Id = reservation.Id,
                        ReservationNumber = $"{reservation.Id}{reservation.RoomId}",
                        RoomId = reservation.RoomId,
                        DateFrom = reservation.DateFrom.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                        DateTo = reservation.DateTo.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Status = ((ReservationStatuses)reservation.StatusId).GetDescription(),
                        DateCreated = reservation.DateCreated.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                        TotalPrice = reservation.TotalPrice
                    }
                );
            }

            return Ok(reservationsToReturn);
        }
    }
}
