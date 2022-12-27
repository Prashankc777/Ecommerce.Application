using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.DTOs.ProductDtos
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public DateTime? ModifiedDate { get; set; }
        //public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

    }
}
