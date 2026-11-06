using LearningManagementApp.Models;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningManagementApp.Controllers
{
    public class AppCourseController : Controller
    {
        protected readonly IRepository repository;
        public AppCourseController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            ViewBag.IsStudentView = false;
            var res = repository.GetAllCourses().ToList();

            List<AppCourse> appcourses = new List<AppCourse>();
            foreach (var item in res)
            {
                AppCourse course = new AppCourse();
                course.Technology = new Technology();
                
                course.Name = item.Name;
                course.Duration = item.Duration;
                course.TechnologyId = item.TechnologyId;
                course.Technology.Name = item.Technology.Name;
                appcourses.Add(course);

            }
            return View(appcourses);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppCourse course)
        {
            try
            {
                Course course1 = new Course();
                course1.Name = course.Name;
                course1.Duration = course.Duration;
                course1.TechnologyId = course.TechnologyId;
                repository.AddCourse(course1);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ByTechnology(int id)
        {
            ViewBag.IsStudentView = true;
            var res = repository.GetCoursesForTechnology(id);

            List<AppCourse> appcourses = new List<AppCourse>();
            foreach (var item in res)
            {
                AppCourse course = new AppCourse();
                course.Id = item.Id;
                course.Name = item.Name;
                course.Duration = item.Duration;
                course.TechnologyId = item.TechnologyId;
                appcourses.Add(course);

            }
            return View("Index", appcourses);
        }

        public ActionResult RegisterCourse(int courseid)
        {
            try
            {
                var userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = repository.GetUser(userid);
                var res = repository.RegisterCourse(user, courseid);

                return View();
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
