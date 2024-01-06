using System;
using System.Collections.Generic;

namespace HotelFlow.Models
{
    public partial class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
