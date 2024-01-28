using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services.DBServices
{
    public class FloorSchemaService
    {
        private readonly HotelFlowContext _context;

        public FloorSchemaService(HotelFlowContext context)
        {
            _context = context;
        }

        public FloorSchema CreateFloorSchema(FloorSchemaDto floorSchemaDto)
        {
            var floorSchema = new FloorSchema
            {
                FloorNumber = floorSchemaDto.FloorNumber,
                Width = floorSchemaDto.Width,
                Height = floorSchemaDto.Height,
                DateCreated = DateTime.Now
            };

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

        public FloorSchema UpdateFloorSchema(int id, FloorSchemaDto floorSchemaDto)
        {
            var floorSchema = _context.FloorSchemas.Find(id);
            if (floorSchema == null)
            {
                return null;
            }
            floorSchema.FloorNumber = floorSchemaDto.FloorNumber;
            floorSchema.Width = floorSchemaDto.Width;
            floorSchema.Height = floorSchemaDto.Height;
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
