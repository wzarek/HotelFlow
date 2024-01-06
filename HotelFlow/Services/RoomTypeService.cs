using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services
{
    public class RoomTypeService
    {
        private readonly HotelFlowContext _context;

        public RoomTypeService(HotelFlowContext context)
        {
            _context = context;
        }

        public RoomType CreateRoomType(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            _context.SaveChanges();
            return roomType;
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return _context.RoomTypes.ToList();
        }

        public RoomType GetRoomTypeById(int id)
        {
            return _context.RoomTypes.FirstOrDefault(r => r.Id == id);
        }

        public List<RoomType> GetRoomTypesByFilter(Expression<Func<RoomType, bool>> filter)
        {
            return _context.RoomTypes.Where(filter).ToList();
        }

        public RoomType UpdateRoomType(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
            _context.SaveChanges();
            return roomType;
        }

        public void DeleteRoomType(int id)
        {
            var roomType = _context.RoomTypes.FirstOrDefault(r => r.Id == id);
            if (roomType != null)
            {
                _context.RoomTypes.Remove(roomType);
                _context.SaveChanges();
            }
        }
    }
}
