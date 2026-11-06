
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoAPI_MSDemo.DataAccess;
using TodoAPI_MSDemo.Model;

namespace TodoAPI_MSDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDBContext>(options =>options.UseInMemoryDatabase("ToDos"));

            
            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            AppDBContext db = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDBContext>();
            db.Todos.AddRange(new ToDoModel { Id = 1, Name = "Eat", IsComplete = true }, new ToDoModel { Id = 2, Name = "Sleep", IsComplete = false });
            db.SaveChanges();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.MapGet("/GetTodos", async (AppDBContext db) => await db.Todos.ToListAsync());

            app.MapGet("/GetTodos/{id}", async (AppDBContext db, int id) => await db.Todos.Where(x => x.Id == id).ToListAsync()
            );

            app.MapGet("/GetTodos/completed", async (AppDBContext db) => await db.Todos.Where(x => x.IsComplete).ToListAsync());

            app.MapGet("/GetTodos/Name/{cl%}", async (AppDBContext db) => await db.Todos.Where(x => x.Name.StartsWith("cl")).ToListAsync());

            app.MapPost("/AddTodo", async (AppDBContext db, ToDoModel todo) => { db.Todos.Add(todo); await db.SaveChangesAsync();  Results.Ok(todo); });

            app.MapPut("/UpdateTodo/{id}", async (AppDBContext db,ToDoModel toDo, int id) =>
            {
                if (await db.Todos.AnyAsync(x=>x.Id ==id) !=null)
                {
                    db.Todos.Update(toDo);
                    await db.SaveChangesAsync();
                    return Results.Ok("updated");
                }
                else
                {
                    return Results.NotFound("id not found");
                }

            });

        app.MapDelete("/DeleteTodo/{id}", async (AppDBContext db, int id) => { 
                var res = await db.Todos.FindAsync(id);
                if (res != null) {
                    db.Todos.Remove(res);
                    await db.SaveChangesAsync();
                    Results.Ok($"todo deleted {id}");
                }
                else
                {
                    Results.NotFound("Todo not found");
                }
            });
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.Run();
        }
    }
}
