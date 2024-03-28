using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions.Mediator
{
    public static class MediatorExtension
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {

            var assembly = Assembly.Load("Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            return services;
        }
    }
}
