using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfPeople { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
