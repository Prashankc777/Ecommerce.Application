using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
