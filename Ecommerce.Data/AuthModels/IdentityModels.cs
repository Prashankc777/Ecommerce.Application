using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.AuthModels
{
    internal class IdentityModels
    {
    }

    public class ApplicationUserRole : IdentityRole
    { }

    public class ApplicationUser : IdentityUser { }
}
