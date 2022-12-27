using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.DTOs.ProductDtos
{
    public class ProductInsertDto
    {
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
