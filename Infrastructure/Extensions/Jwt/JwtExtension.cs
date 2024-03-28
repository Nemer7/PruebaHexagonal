using Domain.Common.Wrappers;
using Domain.Settings.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace Infrastructure.Extensions.Jwt
{
    public static class JwtExtension
    {
        public static void AddJsonWebToken(this IServiceCollection services,
                                          IConfiguration configuration)
        {
            services.ConfigureOptions<JwtSetup>();

            services.AddHttpContextAccessor()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var issuer = configuration["JwtSettings:Issuer"];
                    var audience = configuration["JwtSettings:Audience"];
                    var secretKey = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]);
                    var encryptionKey = Encoding.UTF8.GetBytes(configuration["JwtSettings:Encryptkey"]);

                    var validationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        RequireSignedTokens = true,

                        ValidateIssuer = true,
                        ValidIssuer = issuer,

                        ValidateAudience = true,
                        ValidAudience = audience,

                        RequireExpirationTime = true,
                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey),

                        TokenDecryptionKey = new SymmetricSecurityKey(encryptionKey),
                    };

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = validationParameters;

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception is SecurityTokenMalformedException)
                            {
                                context.Response.StatusCode = 400; 
                                context.Response.ContentType = "application/json";

                                var result = JsonConvert.SerializeObject(new Response<string>(400, "El token JWT no está bien formado"));
                                return context.Response.WriteAsync(result);
                            }
                            if (context.Exception is SecurityTokenSignatureKeyNotFoundException)
                            {
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";

                                var result = JsonConvert.SerializeObject(new Response<string>(401, "Token no válido debido a un problema de firma"));
                                return context.Response.WriteAsync(result);
                            }
                            else if (context.Exception is SecurityTokenExpiredException)
                            {
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";

                                var result = JsonConvert.SerializeObject(new Response<string>(401, "El token ha expirado"));
                                return context.Response.WriteAsync(result);
                            }

                            context.NoResult();
                            context.Response.StatusCode = 500;
                            context.Response.ContentType = "text/plain";
                            return context.Response.WriteAsync(context.Exception.ToString());
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            if (!context.Response.HasStarted)
                            {
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";

                                var result = JsonConvert.SerializeObject(new Response<string>(401, "usted no está autorizado"));
                                return context.Response.WriteAsync(result);
                            }

                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = 400;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>(401, "usted no tiene permiso sobre este recurso"));
                            return context.Response.WriteAsync(result);
                        } 
                    };
                });
        }
    }
}
