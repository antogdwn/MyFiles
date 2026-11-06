namespace TaskManagementSystem.Models
{
    public class Project
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public  bool IsArchived {  get; set; }  

        public required string OwnerId { get; set; }
        public  ApplicationUser? Owner { get; set; }  
        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();


    }

}
