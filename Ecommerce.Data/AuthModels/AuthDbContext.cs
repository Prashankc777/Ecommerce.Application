﻿

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.AuthModels
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, string>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        { }
    }
}
