using LearningManagementApp.Models;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningManagementApp.Controllers
{
    public class AppUserController : Controller
    {
        protected readonly IRepository repository;
        public AppUserController(IRepository _repository)
        {
            repository = _repository;
        }

        // GET: UserController
        public ActionResult Register()
        {

            return View("Create");
        }


        public ActionResult Login()
        {

            return View("Login");


        }
        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            var res = repository.ValidateUser(username, password);
            if (res != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, res.UserName), new Claim(ClaimTypes.NameIdentifier, res.Id.ToString()) };

                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                 await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                return RedirectToAction("UserIndex", "AppTechnology");
            }
            else
            {
                var error = new ErrorViewModel();
                
                error.RequestId = "Error occured";
                return View("Error",error);
            }

        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                repository.AddUser(user);
                return RedirectToAction("Login");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
