//using DataAccess.Models;
using DataAccess.Repository;
using LifeLineHospitalApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeLineHospitalApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IRepository repository;
        public PatientController(IRepository _repository)
        {
            repository = _repository;

        }

        [HttpGet]
        public IActionResult Index()
        {
            var patients = repository.GetAllPatients().ToList();
            List<LifeLineHospitalApp.Models.Patient> patientList = new();


            foreach (var patient in patients)
            {
                LifeLineHospitalApp.Models.Patient tempPatient = new();
                tempPatient.PatientId = patient.PatientId;
                tempPatient.PatientName = patient.PatientName;
                tempPatient.PatientAge = patient.PatientAge;
                tempPatient.ContactNo = patient.ContactNo;

                patientList.Add(tempPatient);
            }
            return View(patientList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                DataAccess.Models.Patient tempPatient = new();
                tempPatient.PatientName = patient.PatientName;
                tempPatient.PatientAge = patient.PatientAge;
                tempPatient.ContactNo = patient.ContactNo;

                repository.AddPatient(tempPatient);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var res = repository.GetPatientById(id);
            LifeLineHospitalApp.Models.Patient tempPatient = new();
            tempPatient.PatientId = res.PatientId;
            tempPatient.PatientName = res.PatientName;
            tempPatient.PatientAge = res.PatientAge;
            tempPatient.ContactNo = res.ContactNo;
            return View(tempPatient);

        }
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                DataAccess.Models.Patient tempPatient = new();
                tempPatient.PatientName = patient.PatientName;
                tempPatient.PatientAge = patient.PatientAge;
                tempPatient.ContactNo = patient.ContactNo;
                tempPatient.PatientId = patient.PatientId;
                repository.UpdatePatient(tempPatient);

                return View();
            }
            else
            {
                return View("Error");
            }

            //return View();

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var res = repository.GetPatientById(id);
            LifeLineHospitalApp.Models.Patient tempPatient = new();
            tempPatient.PatientId = res.PatientId;
            tempPatient.PatientName = res.PatientName;
            tempPatient.PatientAge = res.PatientAge;
            tempPatient.ContactNo = res.ContactNo;
            return View(tempPatient);

        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int patientId)
        {
            //var res = repository.GetPatientById(patientId);
            repository.DeletePatient(patientId);
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            
            var res = repository.GetPatientById(id);
            LifeLineHospitalApp.Models.Patient tempPatient = new();
            tempPatient.Appointments = new List<LifeLineHospitalApp.Models.Appointment>();

            tempPatient.PatientId = res.PatientId;
            tempPatient.PatientName = res.PatientName;
            tempPatient.PatientAge = res.PatientAge;
            tempPatient.ContactNo = res.ContactNo;
            foreach(var item in res.appointments)
            {
                LifeLineHospitalApp.Models.Appointment tempAppointment = new();
                tempAppointment.AppointmentId = item.AppointmentId;
                tempAppointment.AppointmentDate = item.AppointmentDate;
               

                tempPatient.Appointments.Add(tempAppointment);
            }
            
            return View(tempPatient);

        }
        //[HttpGet]
        //public IActionResult PatientAppointments(int id)
        //{
        //    var res = repository.GetPatientAppointmentsById(id);  
        //    return View(res);
        //}


    } 
}
