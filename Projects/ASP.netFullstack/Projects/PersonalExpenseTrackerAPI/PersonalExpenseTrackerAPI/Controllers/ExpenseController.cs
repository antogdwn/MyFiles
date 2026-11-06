using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTrackerAPI.DTOs;
using PersonalExpenseTrackerAPI.Services;

namespace PersonalExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {

            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpensesById(int id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] ExpenseDTO expenseDTO)
        {

            var addedExpense = await _expenseService.AddExpenseAsync(expenseDTO);
            //await _expenseService.SaveChangesAsync();
            return Ok(addedExpense);//CreatedAtAction(nameof(GetExpensesById),new {id=expenseDTO.id});

        }
        [HttpPut]
        public async Task<IActionResult> UpdateExpense([FromBody] ExpenseDTO expenseDTO)
        {

            if (await _expenseService.GetExpenseByIdAsync(expenseDTO.Id) == null)
            {
                return NotFound($"Expense with ID {expenseDTO.Id} not found.");
            }
            var updatedExpense = await _expenseService.UpdateExpenseAsync(expenseDTO);
            return Ok(updatedExpense);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var existingExpense =await _expenseService.GetExpenseByIdAsync(id);
            if(existingExpense == null)
            {
                return NotFound($"Expense with ID {id} not found.");
            }
            await _expenseService.DeleteExpenseByIdAsync(id);
            return Ok("Expense deleted");
        }

    }
}
