using LearningManagementApp.Models;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementApp.Controllers
{
    public class AppTechnologyController : Controller
    {
        protected readonly IRepository repository;

        public AppTechnologyController(IRepository _repository)
        {
            repository= _repository;
        }
        // GET: TechnologyController
        public ActionResult Index()
        {
            var res = repository.GetAllTechnologies();
            List<AppTechnology> appTechnologies = new List<AppTechnology>();
            foreach(var item in res)
            {
                AppTechnology technology = new AppTechnology();
                technology.Id = item.Id;
                technology.Name = item.Name;
                technology.Description = item.Description;
                technology.CourseLink = item.CourseLink;
                appTechnologies.Add(technology);
                
            }
            return View(appTechnologies);
            //return View("~/Views/Shared/_Index.cshtml", appTechnologies);
        }

        public ActionResult UserIndex()
        {
            var res = repository.GetAllTechnologies();
            List<AppTechnology> appTechnologies = new List<AppTechnology>();
            foreach (var item in res)
            {
                AppTechnology technology = new AppTechnology();
                technology.Id = item.Id;
                technology.Name = item.Name;
                technology.Description = item.Description;
                technology.CourseLink = item.CourseLink;
                appTechnologies.Add(technology);

            }
            //return View(appTechnologies);
            return View("~/Views/Shared/_Index.cshtml", appTechnologies);
        }

        // GET: TechnologyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TechnologyController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TechnologyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppTechnology technology)
        {
            try
            {
                LearningManagementSystem.Models.Technology technology1 = new LearningManagementSystem.Models.Technology();
                
                technology1.Name= technology.Name;
                technology1.Description = technology.Description;
                technology1.CourseLink = technology.CourseLink;

                repository.AddTechnology(technology1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TechnologyController/Edit/5
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var res = repository.GetTechnologyById(Id);
            AppTechnology technology = new AppTechnology();
            technology.Id = res.Id;
            technology.Name = res.Name;
            technology.Description = res.Description;
            technology.CourseLink = res.CourseLink;
           

            return View(technology);
        }

        // POST: TechnologyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, AppTechnology technology)
        {
            try
            {
                Technology technology1 = new Technology();
                technology1.Id = technology.Id;
                technology1.Name = technology.Name;
                technology1.Description = technology.Description;
                technology1.CourseLink = technology.CourseLink;
                repository.UpdateTechnology(technology1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TechnologyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TechnologyController/Delete/5
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

        
    }
}
