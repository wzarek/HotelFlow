using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using HotelFlow.Helpers;
using HotelFlow.Models.DTO;
using Microsoft.EntityFrameworkCore;
using static HotelFlow.Helpers.Constants;

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

        public void CreateRooms(IEnumerable<RoomDto> roomsDto)
        {
            foreach (RoomDto roomDto in roomsDto)
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
            }
            _context.SaveChanges();
        }

        public IEnumerable<Room> GetAllRooms(bool getInactiveRooms = false)
        {
            return _context.Rooms.Where(r => r.IsActive || getInactiveRooms)
                .Include(r => r.Type)
                .Include(r => r.Status)
                .ToList();
        }

        public IEnumerable<Room> GetTopNRoomsWithOffset(int offset, int n = 50, bool getInactiveRooms = false)
        {
            return _context.Rooms.Where(r => r.IsActive || getInactiveRooms).Skip(n * offset).Take(n).ToList();
        }

        public Room GetRoomById(int id)
        {
            var room = _context.Rooms
                .Include(r => r.Type)
                .Include(r => r.Status)
                .FirstOrDefault(r => r.Id == id);

            return room;
        }

        public IEnumerable<Room> GetRoomsByFilter(Expression<Func<Room, bool>> filter)
        {
            return _context.Rooms.Where(filter)
                .Include(r => r.Type)
                .Include(r => r.Status)
                .ToList();
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

        public void UpdateRooms(IEnumerable<int> ids, IEnumerable<RoomDto> roomsDto)
        {
            var zipped = ids.Zip(roomsDto);
            foreach (var roomDto in zipped)
            {
                var room = _context.Rooms.Find(roomDto.First);
                if (room == null)
                {
                    continue;
                }
                room.Number = roomDto.Second.Number;
                room.TypeId = roomDto.Second.TypeId;
                room.StatusId = roomDto.Second.StatusId;
                room.IsActive = roomDto.Second.IsActive;

            }
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
