using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    //public class CleaningHistoryDto
    //{
    //    public int RoomId { get; set; }
    //    public int EmployeeId { get; set; }
    //    public DateTime DateCleaned { get; set; }
    //}
    public partial class CleaningHistory
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateCleaned { get; set; }

        public virtual User Employee { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
