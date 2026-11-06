using PersonalExpenseTrackerAPI.Model;

namespace PersonalExpenseTrackerAPI.Repository
{
    public interface IExpenseRepository
    {
        Task<Expense>  AddExpenseAsync(Expense expense);
        Task<Expense> UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseByIdAsync(int id);
        Task<Expense?> GetExpenseByIdAsync(int id);
        Task<List<Expense>> GetAllExpensesAsync();

        Task SaveChangesAsync();
       // Task<List<Expense>> GetExpenseByCategory(int categoryId);
    }
}
