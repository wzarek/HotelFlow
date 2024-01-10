using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    public partial class RoomStatus
    {
        public RoomStatus()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
