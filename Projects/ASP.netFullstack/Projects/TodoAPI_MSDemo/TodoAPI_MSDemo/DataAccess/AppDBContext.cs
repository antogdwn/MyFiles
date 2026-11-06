using Microsoft.EntityFrameworkCore;
using TodoAPI_MSDemo.Model;

namespace TodoAPI_MSDemo.DataAccess
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options) { }
        
        public DbSet<ToDoModel>  Todos { get; set; }
                 

    }
}
