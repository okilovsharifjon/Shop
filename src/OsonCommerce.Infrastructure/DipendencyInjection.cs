﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Infrastructure.Repositories;
using OsonCommerce.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Infrastructure.Authentication;

namespace OsonCommerce.Infrastructure;

public static class DipendencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepository<Product>, Repository<Product>>();
        services.AddScoped<IRepository<Category>, Repository<Category>>();
        services.AddScoped<IRepository<Stock>, Repository<Stock>>();
        services.AddScoped<IRepository<Employee>, Repository<Employee>>();
        services.AddScoped<IRepository<Manufacture>, Repository<Manufacture>>();
        services.AddScoped<IRepository<ProductInStock>, Repository<ProductInStock>>();
        services.AddScoped<IRepository<Provider>, Repository<Provider>>();
        services.AddScoped<IRepository<StoreBranch>, Repository<StoreBranch>>();
        services.AddScoped<IRepository<Role>, Repository<Role>>();
        services.AddScoped<IRepository<PriceType>, Repository<PriceType>>();
        services.AddScoped<IRepository<ProductAttribute>, Repository<ProductAttribute>>();
        services.AddScoped<IRepository<ProductPrice>, Repository<ProductPrice>>();
        services.AddScoped<IRepository<CashboxOperation>, Repository<CashboxOperation>>();
        services.AddScoped<ICashboxRepository, CashboxRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPriceTypeRepository, PriceTypeRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        var jwtOptions = new JwtOptions();
        configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions);
        services.Configure<JwtOptions>(options => 
        {
            options.ExpireHours = jwtOptions.ExpireHours;
            options.SecretKey = jwtOptions.SecretKey;
        });

        services.AddDbContext<OsonCommerceDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}
