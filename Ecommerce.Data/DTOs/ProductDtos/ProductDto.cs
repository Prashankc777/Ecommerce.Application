using Ecommerce.Data.DTOs.CategoryDtos;
using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.DTOs.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public int CategoryId { get; set; }

        public virtual CategoryDto Category { get; set; } = null!;
    }
}
