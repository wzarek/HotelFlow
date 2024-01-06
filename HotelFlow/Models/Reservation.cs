﻿using System;
using System.Collections.Generic;

namespace HotelFlow.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int RoomId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int StatusId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User Customer { get; set; } = null!;
        public virtual User Employee { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual ReservationStatus Status { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
