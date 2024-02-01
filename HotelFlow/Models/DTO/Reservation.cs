using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    public class ReservationDto
    {
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int StatusId { get; set; }
        public int TotalPrice { get; set; }
    }

    public class ReservationFromFrontend
    {
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int StatusId { get; set; }
    }

    public class ReservationDataToSend
    {
        public int Id { get; set; }
        public string ReservationNumber { get; set; }
        public int RoomId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Status { get; set; }
        public string DateCreated { get; set; }
        public int TotalPrice { get; set; }
    }

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
        public int TotalPrice { get; set; }

        public virtual User Customer { get; set; } = null!;
        public virtual User Employee { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual ReservationStatus Status { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
