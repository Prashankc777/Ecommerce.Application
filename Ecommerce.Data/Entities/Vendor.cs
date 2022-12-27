using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class Vendor
    {
        public Vendor()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Contact { get; set; } = null!;

        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
