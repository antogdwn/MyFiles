using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Models
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string CourseLink { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
       
    }
}
/* * technology : id , name, description, Link of courses*/
