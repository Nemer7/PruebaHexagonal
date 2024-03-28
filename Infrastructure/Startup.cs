using Infrastructure.Extensions.Jwt;
using Infrastructure.Extensions.Mapper;
using Infrastructure.Extensions.Mediator;
using Infrastructure.Extensions.Middleware;
using Infrastructure.Extensions.Persistence;
using Infrastructure.Extensions.Services;
using Infrastructure.Extensions.Swagger;
using Infrastructure.Extensions.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Startup
    {

        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            
            service.AddMediator();
            service.AddJsonWebToken(configuration);
            service.AddDomainServices();
            service.AddPesistence(configuration);
            service.AddMongoContext(configuration);
            service.AddSwagger();
            service.AddValidator();
            service.AddMapper();
            service.AddHttpClient();

          
        }

        public static void UseInfrastructure(this IApplicationBuilder builder)
        {
            builder.UseErrorMiddleware();
            builder.UseSwagger();
        }


    }
}
