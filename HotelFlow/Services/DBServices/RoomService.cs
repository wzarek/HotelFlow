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

        public Room CreateRoom(RoomDto roomDto)
        {
            var room = new Room
            {
                Number = roomDto.Number,
                TypeId = roomDto.TypeId,
                StatusId = roomDto.StatusId,
                IsActive = roomDto.IsActive,
                DateCreated = DateTime.Now
            };

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

        public Room UpdateRoom(int roomId, RoomDto roomDto)
        {
            var room = _context.Rooms.Find(roomId);
            if (room == null)
            {
                return null;
            }
            room.Number = roomDto.Number;
            room.TypeId = roomDto.TypeId;
            room.StatusId = roomDto.StatusId;
            room.IsActive = roomDto.IsActive;
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
            var rooms = _context.Rooms.Where(r => ids.Contains(r.Id));
            if (rooms.Any())
            {
                _context.Rooms.RemoveRange(rooms);
                _context.SaveChanges();
            }
        }
    }
}
