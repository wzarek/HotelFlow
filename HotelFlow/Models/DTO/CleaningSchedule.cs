﻿using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    public class CleaningScheduleDto
    {
        public int RoomId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateToBeCleaned { get; set; }
    }
    public class CleaningScheduleFromFrontEnd
    {
        public int RoomId { get; set; }
        public int EmployeeId { get; set; }
        public string DateToBeCleaned { get; set; }
    }


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
