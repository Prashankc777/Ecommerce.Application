using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.DTOs
{
    public class CartDto
    {
        public CartDto()
        {
            Product = new Product();
        }
        public int ProductId { get; set; }
        public int? UserId { get; set; }
        public Product Product { get; set; } = null!;
    }

    public class CartInsertDto : CartDto
    {
        
    }

    public class CartUpdateDto : CartDto
    {
        public int Id { get; set; }

    }

    public class CartDeleteDto : CartDto
    {
        public int Id { get; set; }
    }

    public class CartGetDto : CartDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
