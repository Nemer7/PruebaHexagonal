using Infrastructure.Pipelines;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Extensions.Middleware
{
    public static class MiddlewareExtension
    {
        public static void UseErrorMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddleware>();
        }
        }
    }
