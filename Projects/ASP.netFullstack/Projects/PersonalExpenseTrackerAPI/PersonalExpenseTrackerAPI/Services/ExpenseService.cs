using PersonalExpenseTrackerAPI.DTOs;
using PersonalExpenseTrackerAPI.Model;
using PersonalExpenseTrackerAPI.Repository;

namespace PersonalExpenseTrackerAPI.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _repository = expenseRepository;
        }

        public async Task<ExpenseDTO> AddExpenseAsync(ExpenseDTO expense)
        {
            var expenseModel = new Expense
            {

                UserId = expense.UserId,
                Title = expense.Title,
                Amount = expense.Amount,
                Category = expense.Category,
                ExpenseDate = expense.ExpenseDate,
                Notes = expense.Notes,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow

            };
            var savedExpense = await _repository.AddExpenseAsync(expenseModel);
            return new ExpenseDTO
            {

                Id = savedExpense.Id,
                UserId = savedExpense.UserId,
                Title = savedExpense.Title,
                Amount = savedExpense.Amount,
                Category = savedExpense.Category,
                ExpenseDate = savedExpense.ExpenseDate,
                Notes = savedExpense.Notes,
                CreatedAt = savedExpense.CreatedAt

            };
        }

        public async Task DeleteExpenseByIdAsync(int id)
        {
            await _repository.DeleteExpenseByIdAsync(id);
        }

        public async Task<List<ExpenseDTO>> GetAllExpensesAsync()
        {
            var listExpense = await _repository.GetAllExpensesAsync();
            var listExpenseRes = listExpense.Select(expense => new ExpenseDTO

            {
                Id=expense.Id,
                Title = expense.Title,
                Amount = expense.Amount,
                Category = expense.Category,
                ExpenseDate = expense.ExpenseDate,
                Notes = expense.Notes,
                CreatedAt = expense.CreatedAt,
                UserId=expense.UserId
            }).ToList();

            return listExpenseRes;
        }

        public async Task<ExpenseDTO?> GetExpenseByIdAsync(int id)
        {
            var savedExpense = await _repository.GetExpenseByIdAsync(id);
            if (savedExpense == null)
            {
                throw new Exception($"Id not found {id}");
            }
            else
            {
                return new ExpenseDTO
                {
                    Id = savedExpense.Id,
                    Title = savedExpense.Title,
                    Amount = savedExpense.Amount,
                    Category = savedExpense.Category,
                    ExpenseDate = savedExpense.ExpenseDate,
                    Notes = savedExpense.Notes,
                    CreatedAt = savedExpense.CreatedAt,
                    UserId = savedExpense.UserId

                };
            }
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public async Task<ExpenseDTO> UpdateExpenseAsync(ExpenseDTO expense)
        {
            var expenseModel =new Expense {                
                Id = expense.Id,
                UserId = expense.UserId,
                Title = expense.Title,
                Amount = expense.Amount,
                Category = expense.Category,
                ExpenseDate = expense.ExpenseDate,
                Notes = expense.Notes,
                UpdatedAt = DateTime.UtcNow
            };
            var res = await _repository.UpdateExpenseAsync(expenseModel);
            return new ExpenseDTO {
                Id = res.Id,
                UserId = res.UserId,
                Title = res.Title,
                Amount = res.Amount,
                Category = res.Category,
                ExpenseDate = res.ExpenseDate,
            };
        }
    }
}
