using DataAccess.Data;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HONOrdersDbContex _context;
        protected readonly DbSet<T> _db;

        public Repository(HONOrdersDbContex context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<T?> GetAsync(int id) 
        {
            // TODO: Implement logic to retrieve a single entity by its primary key (id).
            // - Use EF Core async method.
            // - Return null if entity does not exist.
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            // TODO: Implement logic to retrieve all records of type T.
            // - Use EF Core async method.
            // - Return empty list if no records exist.
            throw new NotImplementedException();
        }

        public async Task AddAsync(T entity)
        {
            // TODO: Implement logic to add a new entity to the DbSet.
            // - Do NOT call SaveChanges here.
            // - Persisting changes should happen only when SaveAsync is called.
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            // TODO: Implement logic to save all pending changes to the database.
            // - Use EF Core async save method.
            // - Ensure changes are committed properly.
            throw new NotImplementedException();
        }

    }

}
