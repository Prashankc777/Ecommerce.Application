using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.DTOs
{
    public class VendorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Contact { get; set; } = null!;
    }

    public class VendorInsertDto : VendorDto
    {

    }

    public class VendorUpdateDto : VendorDto
    {
        //public int Id { get; set; }
    }

    public class VendorDeleteDto : VendorDto
    {
        //public int Id { get; set; }
    }

}
