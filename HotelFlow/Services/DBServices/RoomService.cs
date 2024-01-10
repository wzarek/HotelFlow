using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services.DBServices
{
    public class RoomService
    {
        private readonly HotelFlowContext _context;

        public RoomService(HotelFlowContext context)
        {
            _context = context;
        }

        public Room CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return room;
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefault(r => r.Id == id);
        }

        public List<Room> GetRoomsByFilter(Expression<Func<Room, bool>> filter)
        {
            return _context.Rooms.Where(filter).ToList();
        }

        public Room UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return room;
        }

        public void DeleteRoom(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}
