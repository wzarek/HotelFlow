using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services
{
    public class ObjectTypeService
    {
        private readonly HotelFlowContext _context;

        public ObjectTypeService(HotelFlowContext context)
        {
            _context = context;
        }

        public ObjectType CreateObjectType(ObjectType objectType)
        {
            _context.ObjectTypes.Add(objectType);
            _context.SaveChanges();
            return objectType;
        }

        public List<ObjectType> GetAllObjectTypes()
        {
            return _context.ObjectTypes.ToList();
        }

        public ObjectType GetObjectTypeById(int id)
        {
            return _context.ObjectTypes.FirstOrDefault(r => r.Id == id);
        }

        public List<ObjectType> GetObjectTypesByFilter(Expression<Func<ObjectType, bool>> filter)
        {
            return _context.ObjectTypes.Where(filter).ToList();
        }

        public ObjectType UpdateObjectType(ObjectType objectType)
        {
            _context.ObjectTypes.Update(objectType);
            _context.SaveChanges();
            return objectType;
        }

        public void DeleteObjectType(int id)
        {
            var ObjectType = _context.ObjectTypes.FirstOrDefault(r => r.Id == id);
            if (ObjectType != null)
            {
                _context.ObjectTypes.Remove(ObjectType);
                _context.SaveChanges();
            }
        }
    }
}
