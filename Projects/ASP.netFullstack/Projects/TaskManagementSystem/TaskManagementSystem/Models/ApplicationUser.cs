using Microsoft.AspNetCore.Identity;

namespace TaskManagementSystem.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        public string ? AvatarUrl { get;set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        public GlobalRole Role { get; set; }
        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
        public ICollection<TaskAssignee> TaskAssignees { get; set; } = new List<TaskAssignee>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }

    public enum GlobalRole
    {
        Admin,
        Member
    }
}
