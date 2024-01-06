using System;
using System.Collections.Generic;

namespace HotelFlow.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual Reservation Reservation { get; set; } = null!;
    }
}
