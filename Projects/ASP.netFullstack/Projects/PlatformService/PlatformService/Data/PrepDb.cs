using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var servicescope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicescope.ServiceProvider.GetService<AppDbContext>());

            }
        }


        private static void SeedData(AppDbContext context)
        {

            if (!context.Platforms.Any())
            {

                Console.WriteLine("Seeding data...");
                context.Platforms.AddRange(
                    new Platform { Name = "Dot net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "SQL server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }

                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already present");
            }
        }
    }
}
