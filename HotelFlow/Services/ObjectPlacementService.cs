using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services
{
    public class ObjectPlacementService
    {
        private readonly HotelFlowContext _context;

        public ObjectPlacementService(HotelFlowContext context)
        {
            _context = context;
        }

        public ObjectPlacement CreateObjectPlacement(ObjectPlacement objectPlacement)
        {
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

        public ObjectPlacement UpdateObjectPlacement(ObjectPlacement objectPlacement)
        {
            _context.ObjectPlacements.Update(objectPlacement);
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
