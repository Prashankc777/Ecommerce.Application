using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class Slot
    {
        public Slot()
        {
            Bookings = new HashSet<Booking>();
            Parkings = new HashSet<Parking>();
        }

        public int Id { get; set; }
        public int BlockId { get; set; }
        public string Name { get; set; } = null!;
        public string? Alias { get; set; }
        public int VehicleTypeId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Block Block { get; set; } = null!;
        public virtual VehicleType VehicleType { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
    }
}
