namespace TaskManagementSystem.Models
{
    public class ProjectMember
    {
        // Id, ProjectId (FK), UserId (FK), Role (enum: Owner, Admin, Member)

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public  Project? Project { get; set; } 
        public required string UserId { get; set; }
        public  ApplicationUser? User { get; set; } 
        public Role Role { get; set; }

    }

    public enum Role
    {
        Owner,
        Admin,
        Member

    }
}
