using System;
using System.Collections.Generic;

namespace HotelFlow.Models
{
    public partial class ObjectType
    {
        public ObjectType()
        {
            ObjectPlacements = new HashSet<ObjectPlacement>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual ICollection<ObjectPlacement> ObjectPlacements { get; set; }
    }
}
