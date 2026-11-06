using Microsoft.EntityFrameworkCore;
using PersonalExpenseTrackerAPI.Model;
namespace PersonalExpenseTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Expense>()
                 .Property(x => x.Amount)
                 .HasPrecision(18, 2);
        }
    }

}
