using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services.DBServices
{
    public class CleaningScheduleService
    {
        private readonly HotelFlowContext _context;

        public CleaningScheduleService(HotelFlowContext context)
        {
            _context = context;
        }

        public CleaningSchedule CreateCleaningSchedule(CleaningScheduleDto cleaningScheduleDto)
        {
            var cleaningSchedule = new CleaningSchedule
            {
                RoomId = cleaningScheduleDto.RoomId,
                EmployeeId = cleaningScheduleDto.EmployeeId,
                DateToBeCleaned = cleaningScheduleDto.DateToBeCleaned
            };
            _context.CleaningSchedules.Add(cleaningSchedule);
            _context.SaveChanges();
            return cleaningSchedule;
        }

        public List<CleaningSchedule> GetAllCleaningSchedules()
        {
            return _context.CleaningSchedules.ToList();
        }

        public CleaningSchedule GetCleaningScheduleById(int id)
        {
            return _context.CleaningSchedules.FirstOrDefault(r => r.Id == id);
        }

        public List<CleaningSchedule> GetCleaningSchedulesByFilter(Expression<Func<CleaningSchedule, bool>> filter)
        {
            return _context.CleaningSchedules.Where(filter).ToList();
        }

        public CleaningSchedule UpdateCleaningSchedule(int id, CleaningScheduleDto cleaningScheduleDto)
        {
            var cleaningSchedule = _context.CleaningSchedules.Find(id);
            if (cleaningSchedule == null)
            {
                return null;
            }
            cleaningSchedule.RoomId = cleaningScheduleDto.RoomId;
            cleaningSchedule.EmployeeId = cleaningScheduleDto.EmployeeId;
            cleaningSchedule.DateToBeCleaned = cleaningScheduleDto.DateToBeCleaned;
            _context.SaveChanges();
            return cleaningSchedule;
        }

        public void DeleteCleaningSchedule(int id)
        {
            var cleaningSchedule = _context.CleaningSchedules.FirstOrDefault(r => r.Id == id);
            if (cleaningSchedule != null)
            {
                _context.CleaningSchedules.Remove(cleaningSchedule);
                _context.SaveChanges();
            }
        }
    }
}
