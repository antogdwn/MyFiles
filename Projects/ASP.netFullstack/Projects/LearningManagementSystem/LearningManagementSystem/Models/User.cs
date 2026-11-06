using LearningManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Models
{
    public  class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
/*User : id , name, email, username, password 
 
 user can register to courses and can view technologies 

 */
