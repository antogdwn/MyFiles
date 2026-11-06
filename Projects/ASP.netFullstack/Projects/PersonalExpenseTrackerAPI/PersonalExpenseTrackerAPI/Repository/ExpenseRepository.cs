using Microsoft.EntityFrameworkCore;
using PersonalExpenseTrackerAPI.Data;
using PersonalExpenseTrackerAPI.Model;

namespace PersonalExpenseTrackerAPI.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _appDbContext;
        public ExpenseRepository(AppDbContext dbContext) 
        {
            _appDbContext= dbContext;
        }
        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            await _appDbContext.Expenses.AddAsync(expense);
            await _appDbContext.SaveChangesAsync();
            return expense;
        }
      
        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            try
            {
                return await _appDbContext.Expenses.ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            try
            {
                return await _appDbContext.Expenses.FindAsync(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }

        public async Task<Expense> UpdateExpenseAsync(Expense expense)
        {
            try
            {
                var existingExpense = await _appDbContext.Expenses.FindAsync(expense.Id);
                if(existingExpense == null)
                {
                    throw new Exception($"Expense with id {expense.Id} doesnt exist");
                }
                else
                {
                    existingExpense.Title= expense.Title;
                    existingExpense.Amount= expense.Amount;
                    existingExpense.Category= expense.Category;
                    existingExpense.ExpenseDate= expense.ExpenseDate;
                    existingExpense.Notes= expense.Notes;
                    _appDbContext.Expenses.Update(existingExpense);
                    await _appDbContext.SaveChangesAsync();
                    return existingExpense;
                }
                 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task DeleteExpenseByIdAsync(int id)
        {
            var existingExpense = await _appDbContext.Expenses.FindAsync(id);
            if(existingExpense == null)
            {
                throw new Exception($"Expense with id {id} doesnt exist");
            }
            else
            {
                _appDbContext.Expenses.Remove(existingExpense);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
