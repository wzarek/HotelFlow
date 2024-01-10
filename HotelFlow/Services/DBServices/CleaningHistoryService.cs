using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services.DBServices
{
    public class CleaningHistoryService
    {
        private readonly HotelFlowContext _context;

        public CleaningHistoryService(HotelFlowContext context)
        {
            _context = context;
        }

        public CleaningHistory CreateCleaningHistory(CleaningHistory cleaningHistory)
        {
            _context.CleaningHistories.Add(cleaningHistory);
            _context.SaveChanges();
            return cleaningHistory;
        }

        public List<CleaningHistory> GetAllCleaningHistories()
        {
            return _context.CleaningHistories.ToList();
        }

        public CleaningHistory GetCleaningHistoryById(int id)
        {
            return _context.CleaningHistories.FirstOrDefault(r => r.Id == id);
        }

        public List<CleaningHistory> GetCleaningHistoriesByFilter(Expression<Func<CleaningHistory, bool>> filter)
        {
            return _context.CleaningHistories.Where(filter).ToList();
        }

        public CleaningHistory UpdateCleaningHistory(CleaningHistory cleaningHistory)
        {
            _context.CleaningHistories.Update(cleaningHistory);
            _context.SaveChanges();
            return cleaningHistory;
        }

        public void DeleteCleaningHistory(int id)
        {
            var cleaningHistory = _context.CleaningHistories.FirstOrDefault(r => r.Id == id);
            if (cleaningHistory != null)
            {
                _context.CleaningHistories.Remove(cleaningHistory);
                _context.SaveChanges();
            }
        }
    }
}
