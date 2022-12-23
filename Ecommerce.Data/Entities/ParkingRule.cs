using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class ParkingRule
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int VehicleTypeId { get; set; }
        public int ParkingTypeId { get; set; }
        public decimal PulseRate { get; set; }
        public decimal PulseInMinutes { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public decimal? MinimumPulseInMinute { get; set; }

        public virtual ParkingType ParkingType { get; set; } = null!;
        public virtual VehicleType VehicleType { get; set; } = null!;
    }
}
