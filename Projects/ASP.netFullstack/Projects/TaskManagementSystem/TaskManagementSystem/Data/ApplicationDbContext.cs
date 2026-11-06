using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }   
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskAssignee> TaskAssignees { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




        }

    }
}
