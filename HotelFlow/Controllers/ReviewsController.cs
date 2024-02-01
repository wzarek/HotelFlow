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
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private ReviewService _reviewService { get; set; }

        public ReviewsController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult All()
        {
            return Ok(_reviewService.GetAllReviews());
        }

        [HttpGet]
        [Route("[action]/{offset}")]
        public IActionResult GetWithOffset(int offset)
        {
            if (offset < 0)
            {
                return BadRequest(OffsetWrongExceptionMessage);
            }

            return Ok(_reviewService.GetTopNReviewsWithOffset(offset));
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee,User")]
        [Route("[action]/{reservationId}")]
        public IActionResult GetReviewForReservation(int reservationId)
        {
            if (reservationId < 1)
            {
                return BadRequest();
            }

            var review = _reviewService.GetReviewsByFilter(r => r.ReservationId == reservationId).FirstOrDefault();

            if (review == null)
            {
                return Ok(new { });
            }

            return Ok(review); 
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [Route("[action]")]
        public IActionResult Add(ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                return BadRequest();
            }

            return Ok(_reviewService.CreateReview(reviewDto)); 
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult Delete(Review review)
        {
            if (review == null)
            {
                return BadRequest();
            }

            _reviewService.DeleteReview(review.Id);

            return Ok();
        }
    }
}
