
using Microsoft.EntityFrameworkCore;
using PersonalExpenseTrackerAPI.Data;
using PersonalExpenseTrackerAPI.Repository;
using PersonalExpenseTrackerAPI.Services;
using System.Text.Json.Serialization;

namespace PersonalExpenseTrackerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.LogTo(
                    Console.WriteLine,
                    LogLevel.Debug);
            });

            builder.Services.AddScoped<IExpenseService,ExpenseService>();
            builder.Services.AddScoped<IExpenseRepository ,ExpenseRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:5173") // Allowed domains
                          .AllowAnyHeader()  // Allow all headers
                          .AllowAnyMethod(); // Allow GET, POST, PUT, DELETE, etc.
                });

                // For development only: Allow all origins (⚠️ Not for production)
                //options.AddPolicy("AllowAll", policy =>
                //{
                //    policy.AllowAnyOrigin()
                //          .AllowAnyHeader()
                //          .AllowAnyMethod();
                //});
            });

            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.Converters
                                    .Add(new JsonStringEnumConverter());
                            });
           // builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowReactApp");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
