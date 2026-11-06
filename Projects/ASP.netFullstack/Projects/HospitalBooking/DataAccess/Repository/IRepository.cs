using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository
    {
        public bool AddPatient(Patient patient);
        public bool UpdatePatient(Patient patient);
        public bool DeletePatient(int patientid);
        public Patient GetPatientById(int Patientid);
        public List<Patient> GetAllPatients();

        public bool AddAppointment(Appointment appointment);
        public bool DeleteAppointment(int Appointmentid);
        public List<Appointment> GetAllAppointments();
        public Appointment GetAppointmentByid(int appointmentid);

        //public List<Patient> GetPatientAppointmentsById(int patientid);

    }
}
