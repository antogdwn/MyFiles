using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskManager.Core.Application.Interfaces;
using TaskManager.Core.Entities;
using TaskManager.Web.Models;

namespace TaskManager.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskService _taskService;



        public HomeController(ILogger<HomeController> logger , ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
                //return RedirectToAction("Login", "Account");
           
            var All_Tasks = _taskService.GetAllTaskItemsForUser(UserId);
            return View(All_Tasks);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserId == null) 
            {
                return RedirectToAction("Login", "Account");

            }
            var TaskByID = _taskService.GetTaskItemByID(id, UserId);
            if (TaskByID == null) 
            {
                return NotFound();
            }
            return View(TaskByID);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title","Description", "Duedate")]TaskItem Task)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");

            }
            if (ModelState.IsValid)
            {
                Task.UserId = UserId;
                _taskService.CreateTask(Task, UserId);
                //_taskService.SaveChangesAsync(Task);
                return RedirectToAction(nameof(Index));
            }

            return View(Task);
            
        }


        [HttpGet]
        public IActionResult Update(int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var task = _taskService.GetTaskItemByID(id, userId);

            if (task == null)
            {
                return NotFound(); // Or redirect with error message
            }

            return View(task);
        }

        [HttpPost ]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Title", "Description", "Duedate", "IsCompleted")] TaskItem Task)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");

            }
            if (ModelState.IsValid)
            {
                var Existing_task = _taskService.GetTaskItemByID(id, UserId);
                Task.UserId = UserId;

                Existing_task.Title=Task.Title;
                Existing_task.Duedate = Task.Duedate;
                Existing_task.Description = Task.Description;
                Existing_task.IsCompleted = Task.IsCompleted;

                _taskService.UpdateTask(Existing_task, UserId);
                //_taskService.SaveChangesAsync(Task);
                return RedirectToAction(nameof(Index));
            }

            return View(Task);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var task = _taskService.GetTaskItemByID(id, userId);

            if (task == null)
            {
                return NotFound(); // Or redirect with error message
            }

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTask(int id )
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _taskService.DeleteTask(id, userId);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
