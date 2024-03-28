using Domain.Common.Wrappers;
using Domain.Ports;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Infrastructure.Pipelines
{
    public class ErrorMiddleware
    {

        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>()
                {
                    Success = false,
                    Message = error.Message
                };

                if (error is IErrorHandler errorHandler)
                {
                    await errorHandler.HandlerError(context, responseModel);
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }

    }
}
