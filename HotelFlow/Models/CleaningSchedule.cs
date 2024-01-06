using System;
using System.Collections.Generic;

namespace HotelFlow.Models
{
    public partial class CleaningSchedule
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateToBeCleaned { get; set; }

        public virtual User Employee { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
