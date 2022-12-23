using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class Parking
    {
        public long Id { get; set; }
        public int SlotId { get; set; }
        public int ParkingTypeId { get; set; }
        public decimal PulseRate { get; set; }
        public decimal PulseInMinutes { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string CheckInAdmin { get; set; } = null!;
        public string? CheckOutAdmin { get; set; }
        public string? OwnerName { get; set; }
        public string VehicleNumber { get; set; } = null!;
        public string? MobileNumber { get; set; }
        public string VehiclePreNumber { get; set; } = null!;
        public int VehicleTypeId { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public decimal? MinimumPulseInMinutes { get; set; }
        public string? QrCode { get; set; }

        public virtual ParkingType ParkingType { get; set; } = null!;
        public virtual Slot Slot { get; set; } = null!;
        public virtual VehicleType VehicleType { get; set; } = null!;
    }
}
