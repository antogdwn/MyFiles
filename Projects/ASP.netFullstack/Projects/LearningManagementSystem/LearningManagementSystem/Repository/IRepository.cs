using LearningManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Repository
{
    public interface IRepository
    {
        public User ValidateUser (string username, string password);
        public List<Technology> GetAllTechnologies();
        public List<Course> GetCoursesForTechnology(int id);
        public Technology GetTechnologyById(int id);
        public bool RegisterCourse(User user,int courseid);
        public List<Course> GetAllCourses();
        public Course GetCourseById(int id);

        public bool AddUser(User user);
        public bool AddCourse(Course Course);
        public bool AddTechnology(Technology Tectechnology);
        public bool UpdateTechnology(Technology technology);
        public void SaveChanges();
        public User GetUser(int id);


    }
}
