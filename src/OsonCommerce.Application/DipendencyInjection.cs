using Microsoft.Extensions.DependencyInjection;
using OsonCommerce.Application.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OsonCommerce.Application.Features;

namespace OsonCommerce.Application
{
    public static class DipendencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(config => config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly())));
            services.AddMediatR(typeof(CreateProductCommand).Assembly);
            services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
            return services;
        }
    }
}
