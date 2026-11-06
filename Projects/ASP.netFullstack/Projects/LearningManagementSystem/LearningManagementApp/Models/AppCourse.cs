using LearningManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementApp.Models
{
    public  class AppCourse
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string Duration { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
        public List<User> users { get; set; } = new List<User>();

    }
}
/*
 * 

 * courses : name,duration -user can register to courses
 * 
 * 
 */
