using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services
{
    public class FloorSchemaService
    {
        private readonly HotelFlowContext _context;

        public FloorSchemaService(HotelFlowContext context)
        {
            _context = context;
        }

        public FloorSchema CreateFloorSchema(FloorSchema floorSchema)
        {
            _context.FloorSchemas.Add(floorSchema);
            _context.SaveChanges();
            return floorSchema;
        }

        public List<FloorSchema> GetAllFloorSchemas()
        {
            return _context.FloorSchemas.ToList();
        }

        public FloorSchema GetFloorSchemaById(int id)
        {
            return _context.FloorSchemas.FirstOrDefault(r => r.Id == id);
        }

        public List<FloorSchema> GetFloorSchemasByFilter(Expression<Func<FloorSchema, bool>> filter)
        {
            return _context.FloorSchemas.Where(filter).ToList();
        }

        public FloorSchema UpdateFloorSchema(FloorSchema floorSchema)
        {
            _context.FloorSchemas.Update(floorSchema);
            _context.SaveChanges();
            return floorSchema;
        }

        public void DeleteFloorSchema(int id)
        {
            var floorSchema = _context.FloorSchemas.FirstOrDefault(r => r.Id == id);
            if (floorSchema != null)
            {
                _context.FloorSchemas.Remove(floorSchema);
                _context.SaveChanges();
            }
        }
    }
}
