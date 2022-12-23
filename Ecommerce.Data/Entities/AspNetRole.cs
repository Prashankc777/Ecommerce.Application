using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class AspNetRole
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsSuperRole { get; set; }
    }
}
