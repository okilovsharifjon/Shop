using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Infrastructure.Repositories;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Infrastructure.DbContext;
using OsonCommerce.Infrastructure;

namespace OsonCommerce.Infrastructure
{
    public static class DipendencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OsonCommerceDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Stock>, Repository<Stock>>();
            services.AddScoped<IRepository<Cashbox>, Repository<Cashbox>>();
            return services;
        }
    }
}
