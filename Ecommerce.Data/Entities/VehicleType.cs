using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            ParkingRules = new HashSet<ParkingRule>();
            Parkings = new HashSet<Parking>();
            Slots = new HashSet<Slot>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ParkingRule> ParkingRules { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
