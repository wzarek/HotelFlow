using System;
using System.Collections.Generic;

namespace HotelFlow.Models
{
    public partial class ReservationStatus
    {
        public ReservationStatus()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
