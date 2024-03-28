using Domain.Common.Wrappers;
using Microsoft.AspNetCore.Http;

namespace Domain.Ports
{
    public interface IErrorHandler
    {
        Task HandlerError(HttpContext httpContext, Response<string> response);

    }
}
