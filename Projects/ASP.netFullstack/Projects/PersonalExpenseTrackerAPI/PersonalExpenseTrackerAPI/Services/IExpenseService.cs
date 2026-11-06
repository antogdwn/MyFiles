using PersonalExpenseTrackerAPI.DTOs;


namespace PersonalExpenseTrackerAPI.Services
{
    public interface IExpenseService
    {
        Task<ExpenseDTO> AddExpenseAsync(ExpenseDTO expense);
        Task<ExpenseDTO> UpdateExpenseAsync(ExpenseDTO expense);
        Task DeleteExpenseByIdAsync(int id);
        Task<ExpenseDTO?> GetExpenseByIdAsync(int id);
        Task<List<ExpenseDTO>> GetAllExpensesAsync();

        Task SaveChangesAsync();
    }
}
