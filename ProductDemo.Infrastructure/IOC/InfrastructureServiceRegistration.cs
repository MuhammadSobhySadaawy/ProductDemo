using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductDemo.Domain;
using ProductDemo.Domain.Aggregates;
using ProductDemo.Domain.Entities;
using ProductDemo.Domain.Repositories;
using ProductDemo.Infrastructure.Data;
using ProductDemo.Infrastructure.Data.Db;
using ProductDemo.Infrastructure.Data.Repositories;
namespace ProductDemo.Infrastructure.IOC
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            //services.AddDbContext<EAGPServeBigDbContext>(options =>
            //       options.UseSqlServer(configuration.GetConnectionString("EAGPServeBigConnection")));


            //services.AddIdentity<AspNetUser, IdentityRole>()
            //.AddEntityFrameworkStores<EAGPServeBigDbContext>()
            //.AddDefaultTokenProviders();

        

            //services.AddDbContext<MOTA1umbracoDbContext>(options =>
            //       options.UseSqlServer(configuration.GetConnectionString("MOTA1umbracoConnection")));
            //services.AddScoped<IProductRepository, ProductRepository>();

            //services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IUnitOfWork,UnitOfWork>();
          
          //  services.AddTransient<IRepository<Order>, OrderRepository>();
            return services;
        }
      

    }
}
