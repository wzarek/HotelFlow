using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    public class FloorSchemaDto
    {
        public int FloorNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }
        public partial class FloorSchema
    {
        public FloorSchema()
        {
            ObjectPlacements = new HashSet<ObjectPlacement>();
        }

        public int Id { get; set; }
        public int FloorNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<ObjectPlacement> ObjectPlacements { get; set; }
    }
}
