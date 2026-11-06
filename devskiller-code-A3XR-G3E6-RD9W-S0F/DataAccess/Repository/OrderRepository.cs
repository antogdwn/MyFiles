using DataAccess.Data;
using DataAccess.Helper;
using DataAccess.Model;
using DataAccess.ValueObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public new HONOrdersDbContex _context;
        public OrderRepository(HONOrdersDbContex context) : base(context)
        {
            _context = context;

        }


        //Task 1.1 Get Recent Orders
        public async Task<List<Order>> GetRecentOrdersAsync(DateTime since)
        {
            using (var context = _context)
            {
                var OrderQuery = context.Orders.Where(o => o.OrderDate >= since).ToListAsync();
                return await OrderQuery;

            }


            // TODO:
            // - Return all orders placed on or after the given "since" date.
            // - Use EF Core async query.
            // - Results should be returned as a List<Order>.
            throw new NotImplementedException();
        }

        //  Task 1.3 Async Stream
        public async IAsyncEnumerable<Order> StreamOrders(DateTime since,
            [EnumeratorCancellation] CancellationToken ct)
        {
            // TODO:
            // - Implement async streaming of orders placed on or after "since".
            // - Use paging logic (page size = 3).
            // - Fetch data in batches using Skip() and Take().
            // - Stop when no more records exist.
            // - Respect the provided CancellationToken.
            // - Use yield return for streaming.


            await Task.CompletedTask;

            yield break; // temporary placeholder for compilation
        }


        // Task 1.2 LINQ Join + Grouping
        public async Task<List<TopCustomerDTO>> GetTopCustomersAsync()
        {
            // TODO:
            // - Return Top 5 customers in last 30 days.
            // - Calculate:
            //      CustomerName
            //      OrdersCount (distinct orders)
            //      Revenue (sum of LineTotal)
            // - Sort by Revenue descending.
            // - Use LINQ GroupBy and projection to TopCustomerDTO.
            // - Execute query asynchronously.
            //TopCustomerDTO Result = new TopCustomerDTO();
            await using (var context = _context)
            {

                var query = from Orders in context.Orders
                            join Customers in context.Customers on Orders.CustomerId equals Customers.Id
                            join OrderItems in context.OrderItems on Orders.Id equals OrderItems.OrderId
                            where Orders.OrderDate > DateTime.Now.AddDays(-30)
                            group new
                            {
                                Customers,
                                OrderItems
                            } by Customers.Id into CustomerResult

                            select new TopCustomerDTO
                            {
                                CustomerName = CustomerResult.Select(x => x.Customers.Name).ToString(),
                                OrdersCount = CustomerResult.Select(x => x).Distinct().Count(),
                                Revenue = CustomerResult.Sum(x => x.OrderItems.LineTotal)

                                //context.Orders.gro

                            };
                // Result = query;
                var result = await query.OrderByDescending(x => x.Revenue).Take(5).ToListAsync();
                return  result;

            }


            throw new NotImplementedException();
        }

        //Task 1.4 — Dynamic Predicate(Expression Trees)
        public async Task<List<Order>> SearchOrdersAsync(string? status, DateTime? from, DateTime? to, decimal? minTotal, string? email)
        {
            // TODO:
            // - Use OrderPredicateBuilder.Build(...) to generate filter expression.
            // - Include Customer navigation property.
            // - Apply dynamic filtering using Where(predicate).
            // - Execute asynchronously and return filtered list.

            throw new NotImplementedException();
        }
    }
}
