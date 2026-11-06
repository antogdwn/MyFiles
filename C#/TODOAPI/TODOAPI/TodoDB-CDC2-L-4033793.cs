using Microsoft.EntityFrameworkCore;

namespace TODOAPI
{

    class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<TODO> Todos => Set<TODO>();
    }
}
