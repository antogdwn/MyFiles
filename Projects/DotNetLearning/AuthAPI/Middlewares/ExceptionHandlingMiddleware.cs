using AuthAPI.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AuthAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {

        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
            //_logger = logger;
        }


        public async Task InvokeAsync(HttpContext context, ILoggingService logger)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // LogInformation(string body, string requestmethod, string requestpath, int statuscode, string exceptionmessage, DateTime createdat)

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    ArgumentException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError

                };

                await logger.LogInformation
                    (context.Request.Body.ToString()!,
                    context.Request.Method,
                    context.Request.Path, context.Response.StatusCode,
                    $"Exception {ex.Message}, {ex.InnerException},{ex.StackTrace}"
                    );
                await context.Response.WriteAsJsonAsync(new
                {
                    statusCode = context.Response.StatusCode,
                    message = ex.Message
                });
            }
        }
    }
}
