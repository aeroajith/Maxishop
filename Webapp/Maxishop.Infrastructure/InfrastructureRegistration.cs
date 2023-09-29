using Maxishop.Domain.Contracts;
using Maxishop.Infrastructure.Respositries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<ICatagoryRepository,CatagoryRepository>();
            services.AddScoped<IBrandRepository,BrandRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            return services;
        }
    }
}
