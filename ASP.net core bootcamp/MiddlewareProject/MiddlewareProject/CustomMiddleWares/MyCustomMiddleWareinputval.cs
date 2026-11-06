using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareProject.CustomMiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UseMyCustomMiddleWareinputval
    {
        private readonly RequestDelegate _next;

        public UseMyCustomMiddleWareinputval(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var query = httpContext.Request.Query;

            if (!query.ContainsKey("email") && !query.ContainsKey("password"))
            {
                //httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("No response");
                return;
            }
            // 1. Check if email and password keys exist
            if (!query.ContainsKey("email") || !query.ContainsKey("password"))
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("Invalid Login");
                return;
            }


            string email = query["email"].ToString();
            string pass = query["password"].ToString();

            // 2. Check if values are empty
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                httpContext.Response.StatusCode = 400;

                if (string.IsNullOrWhiteSpace(email))
                    await httpContext.Response.WriteAsync("Invalid input for 'email' \n");

                if (string.IsNullOrWhiteSpace(pass))
                    await httpContext.Response.WriteAsync("Invalid input for 'password' \n");

                return;
            }

            
            await _next(httpContext);
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UseMyCustomMiddleWareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UseMyCustomMiddleWareinputval>();
        }
    }
}
