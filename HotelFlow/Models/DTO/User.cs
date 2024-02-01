using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    public class UserDataDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RoleId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
    }
    public partial class User
    {
        public User()
        {
            CleaningHistories = new HashSet<CleaningHistory>();
            CleaningSchedules = new HashSet<CleaningSchedule>();
            ReservationCustomers = new HashSet<Reservation>();
            ReservationEmployees = new HashSet<Reservation>();
        }
        

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string EmailAddress { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<CleaningHistory> CleaningHistories { get; set; }
        public virtual ICollection<CleaningSchedule> CleaningSchedules { get; set; }
        public virtual ICollection<Reservation> ReservationCustomers { get; set; }
        public virtual ICollection<Reservation> ReservationEmployees { get; set; }
    }
}
