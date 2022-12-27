using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.AuthModels;
using Ecommerce.Data.Entities;
using Ecommerce.Data.Infrastructure;
using Ecommerce.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Data
{
    public static class DataServicesConfiguration
    {
        public static void AddServicesFromData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection").ToString();

            

            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
            });

           // services.AddIdentity<ApplicationUser, ApplicationUserRole>()
           //.AddEntityFrameworkStores<AuthDbContext>()
           //.AddDefaultTokenProviders();





            
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IBlockRepository, BlockRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IVendorRepository, VendorRepository>();
            services.AddTransient<ICartRepository, CartRepository>();


        }
    }
}
