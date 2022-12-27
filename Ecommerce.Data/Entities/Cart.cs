using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UserId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
