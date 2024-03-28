using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions.Mapper
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("Application"));
            return services;
        }
    }
}
