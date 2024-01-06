﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services
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

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.FirstOrDefault(r => r.Id == id);
        }

        public List<Reservation> GetReservationsByFilter(Expression<Func<Reservation, bool>> filter)
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
