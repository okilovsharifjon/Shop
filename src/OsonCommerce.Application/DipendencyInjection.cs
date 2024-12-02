using Microsoft.Extensions.DependencyInjection;
using OsonCommerce.Application.Features;
using FluentValidation;
using OsonCommerce.Application.Common.Mappers;
using System.Reflection;
using MediatR;
using OsonCommerce.Application.Common.Behavior;

namespace OsonCommerce.Application
{
    public static class DipendencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(config => config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly())));
            services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    services.AddValidatorsFromAssembly(assembly);
                }
                catch { } 
            }
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
