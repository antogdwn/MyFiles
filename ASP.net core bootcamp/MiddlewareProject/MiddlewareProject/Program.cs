using Microsoft.AspNetCore.Http;
using MiddlewareProject.CustomMiddleWares;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.UseWhen(context => ! context.Request.Query.ContainsKey("email") && !context.Request.Query.ContainsKey(");//httpContext.Request.Query.ContainsKey("email") || !httpContext.Request.Query.ContainsKey("password"))
app.UseMyCustomMiddleWare();
app.UseCustomMiddleware2();

app.Run();
