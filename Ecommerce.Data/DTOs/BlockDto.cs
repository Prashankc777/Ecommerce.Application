using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.DTOs
{
    public class BlockDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Alias { get; set; }
        public bool IsActive { get; set; } 
       
    }
}
