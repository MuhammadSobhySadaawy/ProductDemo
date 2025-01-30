using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductDemo.Abstraction.Interfaces;
using ProductDemo.Domain.Repositories;
using ProductDemo.Services.Services;

namespace ProductDemo.Services.IOC
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IProductService, ProductService>();

            return services;
        }

    }
}
