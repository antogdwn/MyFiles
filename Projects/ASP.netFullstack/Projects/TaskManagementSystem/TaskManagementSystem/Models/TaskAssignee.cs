namespace TaskManagementSystem.Models
{
    public class TaskAssignee
    {
        //	• Id, TaskId (FK), UserId (FK)

        public int Id { get; set; }
        public int TaskId { get; set; }
        public  TaskItem? TaskItem { get; set; }
        public required string UserId    { get; set; }
        public  ApplicationUser? User  { get; set; }

    }
}
