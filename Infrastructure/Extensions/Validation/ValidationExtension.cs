using FluentValidation;
using Infrastructure.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions.Validation
{
    public static class ValidationExtension
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            var validationAssembly = Assembly.Load("Application");
            services.AddValidatorsFromAssembly(validationAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}
