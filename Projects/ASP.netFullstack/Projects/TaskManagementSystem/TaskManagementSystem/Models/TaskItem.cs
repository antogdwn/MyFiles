namespace TaskManagementSystem.Models
{
    public class TaskItem
    {
       
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public required Project Project { get; set; }

        public required string Title { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public DateTime DueDate { get; set; }

        public required string CreatedById { get; set; }
        public  ApplicationUser? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<TaskAssignee> TaskAssignees { get; set; } = new List<TaskAssignee>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }

    public enum Status
    {
        ToDo,
        InProgress,
        InReview,
        Done
        
    }
    public enum Priority
    {
        Low,
        Medium,
        High,
        Urgent
    }
}
