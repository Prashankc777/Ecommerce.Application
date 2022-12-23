using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class ParkingType
    {
        public ParkingType()
        {
            ParkingRules = new HashSet<ParkingRule>();
            Parkings = new HashSet<Parking>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<ParkingRule> ParkingRules { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
    }
}
