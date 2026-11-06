namespace TaskManagementSystem.Models
{
    public class Comment
    {
        //	• Id, TaskId (FK), UserId (FK), Content, CreatedAt
        
//- FR28: Users can add comments to a task.
//- FR29: Users can edit/delete their own comments.
//- FR30: Comments support @mentions of other project members.
//- FR31: Mentioned users receive a notification.
        public int Id { get; set; }
        public int TaskId { get; set; }
        public  TaskItem? Task { get; set; }
        public required string UserId { get; set; }
        public  ApplicationUser? User { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
