using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    public partial class ObjectPlacement
    {
        public int Id { get; set; }
        public int ObjectTypeId { get; set; }
        public int FloorNumberId { get; set; }
        public string PositionFrom { get; set; } = null!;
        public string PositionTo { get; set; } = null!;
        public int? RoomId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual FloorSchema FloorNumber { get; set; } = null!;
        public virtual ObjectType ObjectType { get; set; } = null!;
        public virtual Room? Room { get; set; }
    }
}
