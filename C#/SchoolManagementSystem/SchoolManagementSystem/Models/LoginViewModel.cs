using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Models
{
    public class LoginViewModel
    {
        public required string Username { get; set; }

        public required string password { get; set; }  

    }
}
