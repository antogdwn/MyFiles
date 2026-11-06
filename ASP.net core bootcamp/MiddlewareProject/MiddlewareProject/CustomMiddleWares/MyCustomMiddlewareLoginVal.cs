using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareProject.CustomMiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyCustomMiddlewareLoginVal
    {
        private readonly RequestDelegate _next;

        public MyCustomMiddlewareLoginVal(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query["email"] == "admin@example.com" && httpContext.Request.Query["password"] == "admin1234")
            {
                // httpContext.Response.StatusCode = 400;
                //await httpContext.Response.WriteAsync("Invalid login");
                await httpContext.Response.WriteAsync("Successful login");
            }
            else
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("Invalid Login");
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddleware2Extensions
    {
        public static IApplicationBuilder UseCustomMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddlewareLoginVal>();
        }
    }
}
