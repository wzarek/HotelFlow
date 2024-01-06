using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services
{
    public class RoomStatusService
    {
        private readonly HotelFlowContext _context;

        public RoomStatusService(HotelFlowContext context)
        {
            _context = context;
        }

        public RoomStatus CreateRoomStatus(RoomStatus roomStatus)
        {
            _context.RoomStatuses.Add(roomStatus);
            _context.SaveChanges();
            return roomStatus;
        }

        public List<RoomStatus> GetAllRoomStatuses()
        {
            return _context.RoomStatuses.ToList();
        }

        public RoomStatus GetRoomStatusById(int id)
        {
            return _context.RoomStatuses.FirstOrDefault(r => r.Id == id);
        }

        public List<RoomStatus> GetRoomStatusesByFilter(Expression<Func<RoomStatus, bool>> filter)
        {
            return _context.RoomStatuses.Where(filter).ToList();
        }

        public RoomStatus UpdateRoomStatus(RoomStatus roomStatus)
        {
            _context.RoomStatuses.Update(roomStatus);
            _context.SaveChanges();
            return roomStatus;
        }

        public void DeleteRoomStatus(int id)
        {
            var roomStatus = _context.RoomStatuses.FirstOrDefault(r => r.Id == id);
            if (roomStatus != null)
            {
                _context.RoomStatuses.Remove(roomStatus);
                _context.SaveChanges();
            }
        }
    }
}
