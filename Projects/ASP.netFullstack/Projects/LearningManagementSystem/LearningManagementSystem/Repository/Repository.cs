using LearningManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using LearningManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Repository
{
    public class Repository : IRepository
    {
        public AppDbContext context;
        public Repository(AppDbContext _context) {
            context = _context;
        }
        public List<Course> GetAllCourses()
        {

            return context.Courses
                .Include(x=>x.Technology)
                .ToList();
        }

        public List<Technology> GetAllTechnologies()
        {
            return context.Technologies.ToList();
        }

        public List<Course> GetCoursesForTechnology(int id)
        {
            return context.Courses.Where(x => x.TechnologyId == id).ToList();
        }

        public bool RegisterCourse(User user, int courseid)
        {
            try
            {
                var currentUser = context.Users.Find(user.Id);
                var registredCourse = context.Courses.Find(courseid);
                currentUser.Courses.Add(registredCourse);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public User ValidateUser(string username, string password)
        {
            try
            {
                var res = context.Users
                            .FirstOrDefault(x => x.UserName == username && x.Password ==password);
                if (res!=null)
                {
                    return res;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }

            
        }

        public bool AddUser(User user)
        {
            try
            {
                //bool res = ValidateUser(user);
                context.Users.Add(user);
                SaveChanges(); ;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Technology GetTechnologyById(int id)
        {
            try
            {
                return context.Technologies.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public Course GetCourseById(int id)
        {

            try
            {
                return context.Courses.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public bool AddCourse(Course course)
        {
            try
            {
                //bool res = ValidateUser(user);
                context.Courses.Add(course);
                SaveChanges(); ;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddTechnology(Technology technology)
        {
            try
            {
                //bool res = ValidateUser(user);
                context.Technologies.Add(technology);
                SaveChanges(); ;
                return true;
            }
            catch
            {
                return false;
            }
        }      

        public bool UpdateTechnology(Technology technology)
        {
            context.Technologies.Update(technology);
            SaveChanges();
            return true;
        }

        public User GetUser(int id)
        {
            try
            {
                return context.Users.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
