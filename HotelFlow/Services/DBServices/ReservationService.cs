using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services.DBServices
{
    public class ReservationService
    {
        private readonly HotelFlowContext _context;

        public ReservationService(HotelFlowContext context)
        {
            _context = context;
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public IEnumerable<Reservation> GetTopNReservationsWithOffset(int offset, int n = 50)
        {
            return _context.Reservations.Skip(n * offset).Take(n).ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Reservation> GetReservationsByFilter(Expression<Func<Reservation, bool>> filter)
        {
            return _context.Reservations.Where(filter).ToList();
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public void DeleteReservation(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }
    }
}
