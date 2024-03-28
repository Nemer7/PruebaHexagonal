using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace Infrastructure.Extensions.Swagger
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);



                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token *only*",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
              {
                  { securityScheme, new List<string>() { } }
              });
                options.ExampleFilters();
            });
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment()) return app;
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DefaultModelExpandDepth(2);
                options.DefaultModelsExpandDepth(-1);
                options.DisplayOperationId();
                options.DisplayRequestDuration();
                options.EnableDeepLinking();
                options.ShowExtensions();
                options.EnableValidator(null);
                options.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
}
