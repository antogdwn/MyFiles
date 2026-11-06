using LearningManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementApp.Models
{
    public  class AppUser
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength (100)]
        public required string UserName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        
        public required string Password { get; set; }
        //public bool IsActive { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
/*User : id , name, email, username, password 
 
 user can register to courses and can view technologies 

 */
