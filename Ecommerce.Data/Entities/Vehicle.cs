using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehiclePreNumber { get; set; } = null!;
        public string VehicleNumber { get; set; } = null!;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual VehicleType VehicleType { get; set; } = null!;
    }
}
