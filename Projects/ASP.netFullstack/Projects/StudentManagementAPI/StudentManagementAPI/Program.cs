
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentManagementAPI.Data;
using StudentManagementAPI.Services;

namespace StudentManagementAPI
{
    public class Program
    {

        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("StudentDb") ?? throw new InvalidProgramException("Student Db connection string is not configured");
           builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            var jwtsettings = builder.Configuration.GetSection("JwtSettings");
            var key = jwtsettings["key"];
            builder.Services.AddTransient<IJWTAuthservice, JWTAuth>();
            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtsettings["Issuer"],
                    ValidAudience = jwtsettings["audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key))
            }; }
            );
            //            builder.Services.AddDbContext<AppDbContext>(); commented out after removing hardcoded connection string from the OnConfiguring method and using dependency injection to pass the connection string from the appsettings.json file.
            builder.Services.AddControllers();

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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
