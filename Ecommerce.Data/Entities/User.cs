using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? AspNetUserId { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual AspNetUser? AspNetUser { get; set; }
    }
}
