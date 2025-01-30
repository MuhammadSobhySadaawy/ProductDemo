using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductDemo.Domain.Repositories;
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
            
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
      

    }
}
