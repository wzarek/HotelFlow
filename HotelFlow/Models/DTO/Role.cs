using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HotelFlow.Models.DTO
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
