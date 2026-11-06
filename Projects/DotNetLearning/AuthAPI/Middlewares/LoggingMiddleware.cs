using AuthAPI.Services;
using Microsoft.AspNetCore.Diagnostics;

namespace AuthAPI.Middlewares
{
    public class LoggingMiddleware 
    {
        private readonly RequestDelegate _next;

        //private readonly ILoggingService _logger;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next=next;
           // _logger=logger;
        }

        public async Task InvokeAsync(HttpContext context,ILoggingService logger)
        {
            //_logger=logger;
            await logger.LogInformation(context.Request.Method, context.Request.Path, context.Request.Body.ToString()!, 0);

            await _next(context);
            await logger.LogInformation(context.Request.Method, context.Request.Path, context.Request.Body.ToString()!, 0);
        }
    }
}
