using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.DTOs.CategoryDtos
{
    public class CategoryInsertDto
    {
        public string Name { get; set; } = null!;
        public string? Alias { get; set; }
    }
}
