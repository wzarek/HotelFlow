using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models.DTO;
using Microsoft.EntityFrameworkCore;
using static HotelFlow.Helpers.Constants;

namespace HotelFlow.Services.DBServices
{
    public class ObjectPlacementService
    {
        private readonly HotelFlowContext _context;

        public ObjectPlacementService(HotelFlowContext context)
        {
            _context = context;
        }

        public ObjectPlacement CreateObjectPlacement(ObjectPlacementDto objectPlacementDto)
        {
            var objectPlacement = new ObjectPlacement
            {
                ObjectTypeId = objectPlacementDto.ObjectTypeId,
                FloorNumberId = objectPlacementDto.FloorNumberId,
                PositionFrom = objectPlacementDto.PositionFrom,
                PositionTo = objectPlacementDto.PositionTo,
                RoomId = objectPlacementDto.RoomId,
                DateCreated = DateTime.Now
            };
            _context.ObjectPlacements.Add(objectPlacement);
            _context.SaveChanges();
            return objectPlacement;
        }

        public List<ObjectPlacement> GetAllObjectPlacements()
        {
            return _context.ObjectPlacements.ToList();
        }

        public ObjectPlacement GetObjectPlacementById(int id)
        {
            return _context.ObjectPlacements.FirstOrDefault(r => r.Id == id);
        }

        public List<ObjectPlacement> GetObjectPlacementsByFilter(Expression<Func<ObjectPlacement, bool>> filter)
        {
            return _context.ObjectPlacements.Where(filter).ToList();
        }

        public ObjectPlacement UpdateObjectPlacement(int id, ObjectPlacementDto objectPlacementDto)
        {
            var objectPlacement = _context.ObjectPlacements.Find(id);
            if(objectPlacement == null)
            {
                return null;
            }
            objectPlacement.ObjectTypeId = objectPlacementDto.ObjectTypeId;
            objectPlacement.FloorNumberId = objectPlacementDto.FloorNumberId;
            objectPlacement.PositionFrom = objectPlacementDto.PositionFrom;
            objectPlacement.PositionTo = objectPlacementDto.PositionTo;
            objectPlacement.RoomId = objectPlacementDto.RoomId;
            _context.SaveChanges();
            return objectPlacement;
        }

        public void DeleteObjectPlacement(int id)
        {
            var objectPlacement = _context.ObjectPlacements.FirstOrDefault(r => r.Id == id);
            if (objectPlacement != null)
            {
                _context.ObjectPlacements.Remove(objectPlacement);
                _context.SaveChanges();
            }
        }
    }
}
