using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services
{
    public class ReservationStatusService
    {
        private readonly HotelFlowContext _context;

        public ReservationStatusService(HotelFlowContext context)
        {
            _context = context;
        }

        public ReservationStatus CreateReservationStatus(ReservationStatus reservationStatus)
        {
            _context.ReservationStatuses.Add(reservationStatus);
            _context.SaveChanges();
            return reservationStatus;
        }

        public List<ReservationStatus> GetAllReservationStatuses()
        {
            return _context.ReservationStatuses.ToList();
        }

        public ReservationStatus GetReservationStatusById(int id)
        {
            return _context.ReservationStatuses.FirstOrDefault(r => r.Id == id);
        }

        public List<ReservationStatus> GetReservationStatusesByFilter(Expression<Func<ReservationStatus, bool>> filter)
        {
            return _context.ReservationStatuses.Where(filter).ToList();
        }

        public ReservationStatus UpdateReservationStatus(ReservationStatus reservationStatus)
        {
            _context.ReservationStatuses.Update(reservationStatus);
            _context.SaveChanges();
            return reservationStatus;
        }

        public void DeleteReservationStatus(int id)
        {
            var reservationStatus = _context.ReservationStatuses.FirstOrDefault(r => r.Id == id);
            if (reservationStatus != null)
            {
                _context.ReservationStatuses.Remove(reservationStatus);
                _context.SaveChanges();
            }
        }
    }
}
