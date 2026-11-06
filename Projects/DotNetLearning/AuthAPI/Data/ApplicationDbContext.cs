using AuthAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        ///public DbSet<ApplicationUser> Users {  get; set; }
        ///
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<APILog>APILogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RefreshToken>()
                .Property(r => r.TokenHash)
                .IsRequired();

        }


    }
}
