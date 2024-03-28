using Domain.Ports.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ISupplierService, SupplierService>();
             
            return services;
        }
    }
}
