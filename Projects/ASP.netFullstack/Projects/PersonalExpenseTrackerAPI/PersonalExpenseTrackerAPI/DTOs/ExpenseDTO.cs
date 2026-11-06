using PersonalExpenseTrackerAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace PersonalExpenseTrackerAPI.DTOs
{
    public class ExpenseDTO
    {
            [Required]
             public int Id { get; set; }

            [MaxLength(100)]
            [Required]
            public string Title { get; set; }
            [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
            public decimal Amount { get; set; }
            [Required]
            public ExpenseCategories Category { get; set; }
            [Required]
            public DateOnly ExpenseDate { get; set; }
            [MaxLength(100)]
            public string? Notes { get; set; }
            
            public DateTime CreatedAt { get; set; }
            public int UserId { get; set; }
    }
}
