using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    public class RoomDto
    {
        public int Number { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public bool IsActive { get; set; }
    }
    public partial class Room
    {
        public Room()
        {
            CleaningHistories = new HashSet<CleaningHistory>();
            CleaningSchedules = new HashSet<CleaningSchedule>();
            ObjectPlacements = new HashSet<ObjectPlacement>();
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual RoomStatus Status { get; set; } = null!;
        public virtual RoomType Type { get; set; } = null!;
        public virtual ICollection<CleaningHistory> CleaningHistories { get; set; }
        public virtual ICollection<CleaningSchedule> CleaningSchedules { get; set; }
        public virtual ICollection<ObjectPlacement> ObjectPlacements { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
