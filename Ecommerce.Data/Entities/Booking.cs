using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string OwnerName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int SlotId { get; set; }
        public string VehiclePreNumber { get; set; } = null!;
        public string VehicleNumber { get; set; } = null!;
        public DateTime CheckInDateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Slot Slot { get; set; } = null!;
    }
}
