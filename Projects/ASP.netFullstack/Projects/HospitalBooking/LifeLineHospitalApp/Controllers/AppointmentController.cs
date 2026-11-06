using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LifeLineHospitalApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IRepository repository;

        public AppointmentController(IRepository _repository)
        {
            repository=_repository;
        }
        // GET: AppointmentController
        public ActionResult Create()
        {
            return View();
        }


        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            try
            {
                
              bool res = repository.AddAppointment(appointment);
                if (res)
                {
                    return RedirectToAction(nameof(Create));
                }
                else {
                    return View("Error");
                
                }
                
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            var res =repository.GetAllAppointments();
            return View(res);
        }

        // GET: AppointmentController/Details/5

        [HttpGet]
        public ActionResult Details(int id)
        {
            var res = repository.GetAppointmentByid(id);
            return View(res);
        }

        

        //// GET: AppointmentController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var res = repository.GetAppointmentByid(id);


        //    return View(res);
        //}

        //// POST: AppointmentController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Appointment appointment)
        //{
        //    try
        //    {
        //        bool res = repository.UpdatePatient(appointment);
        //        if (res)
        //        {
        //            return RedirectToAction(nameof(Create));
        //        }
        //        else
        //        {
        //            return View("Error");

        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = repository.GetAppointmentByid(id);
                        
            return View(res);
           
           
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int AppointmentId)
        {
            try
            {
                repository.DeleteAppointment(AppointmentId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
