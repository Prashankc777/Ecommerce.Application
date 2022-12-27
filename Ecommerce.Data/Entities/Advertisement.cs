using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class Advertisement
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public virtual Vendor Vendor { get; set; } = null!;
    }
}
