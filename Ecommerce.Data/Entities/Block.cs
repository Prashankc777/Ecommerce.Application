﻿using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public partial class Block
    {
        public Block()
        {
            Slots = new HashSet<Slot>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Alias { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Slot> Slots { get; set; }
    }
}
