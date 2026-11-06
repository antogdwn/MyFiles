using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Data
{
    public class AppDbContext :DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }


        //Removing the hardcoded connection string from the OnConfiguring method and using dependency injection to pass the connection string from the appsettings.json file.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");
        //    ///base.OnConfiguring(optionsBuilder);
        //}
    }
}
