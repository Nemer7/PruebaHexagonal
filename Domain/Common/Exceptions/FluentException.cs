using Domain.Common.Wrappers;
using Domain.Ports;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Domain.Common.Exceptions
{
    public class FluentException : Exception, IErrorHandler
    {
        public List<string> ListErrors { get; set; }

        public async Task HandlerError(HttpContext httpContext, Response<string> response)
        {
           response.Errors = ListErrors;
           httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
           response.StatusCode = (int)HttpStatusCode.BadRequest;


        }

        public FluentException(): base()
        {
            ListErrors = new List<string>();
        }

        public FluentException(IEnumerable<string> errors): this()
        {
            ListErrors = errors.ToList();
        }
        

    }
}
