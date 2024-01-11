using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services.DBServices
{
    public class ReviewService
    {
        private readonly HotelFlowContext _context;

        public ReviewService(HotelFlowContext context)
        {
            _context = context;
        }

        public Review CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

        public IEnumerable<Review> GetTopNReviewsWithOffset(int offset, int n = 50)
        {
            return _context.Reviews.Skip(n * offset).Take(n).ToList();
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public List<Review> GetReviewsByFilter(Expression<Func<Review, bool>> filter)
        {
            return _context.Reviews.Where(filter).ToList();
        }

        public Review UpdateReview(Review review)
        {
            _context.Reviews.Update(review);
            _context.SaveChanges();
            return review;
        }

        public void DeleteReview(int id)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }
    }
}
