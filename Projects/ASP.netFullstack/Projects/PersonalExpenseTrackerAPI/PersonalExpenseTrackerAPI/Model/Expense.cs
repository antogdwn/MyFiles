namespace PersonalExpenseTrackerAPI.Model
{
    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategories Category { get; set; }
        public DateOnly ExpenseDate { get; set; }
        public string? Notes { get; set; }
        public int UserId { get; set; } // FK
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }      
    }
    public enum ExpenseCategories
    {
        Food,
        Travel,
        Shopping,
        Bills,
        Health,
        Entertainment,
        Other
    }
}
