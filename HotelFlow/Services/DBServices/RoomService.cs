using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Helpers;
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

        public Room GetEmptyRoom()
        {
            return new Room
            {
                IsActive = true,
                DateCreated = DateTime.Now
            };
        }

        public Room CreateRoom(Room room)
        {
            _context.Rooms.AddIfNotExists(room, r => r.Number == room.Number);
            _context.SaveChanges();
            return room;
        }

        public void CreateRooms(IEnumerable<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                _context.Rooms.AddIfNotExists(room, r => r.Number == room.Number);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Room> GetAllRooms(bool getInactiveRooms = false)
        {
            return _context.Rooms.Where(r => r.IsActive || getInactiveRooms).ToList();
        }

        public IEnumerable<Room> GetTopNRoomsWithOffset(int offset, int n = 50, bool getInactiveRooms = false)
        {
            return _context.Rooms.Where(r => r.IsActive || getInactiveRooms).Skip(n * offset).Take(n).ToList();
        }

        public Room GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Room> GetRoomsByFilter(Expression<Func<Room, bool>> filter)
        {
            return _context.Rooms.Where(filter).ToList();
        }

        public Room UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return room;
        }

        public void UpdateRooms(IEnumerable<Room> rooms)
        {
            _context.Rooms.UpdateRange(rooms);
            _context.SaveChanges();
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

        public void DeleteRooms(IEnumerable<int> ids)
        {
            var rooms = _context.Rooms.Where(u => ids.Contains(u.Id));
            if (rooms.Any())
            {
                _context.Rooms.RemoveRange(rooms);
                _context.SaveChanges();
            }
        }
    }
}
