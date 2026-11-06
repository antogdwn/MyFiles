using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository : IRepository
    {
        public AppDbContext Context;
        public Repository(AppDbContext appDbContext)
        {
            Context = appDbContext;
        }

        public bool AddAppointment(Appointment appointment)
        {
            try
            {
                Context.Appointments.Add(appointment);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool AddPatient(Patient patient)
        {
            try
            {
                Context.Patients.Add(patient);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteAppointment(int AppointmentId)
        {
            try
            {
                var appointment = Context.Appointments.Find(AppointmentId);
                if (appointment != null)
                {

                    Context.Appointments.Remove(appointment);
                    Context.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeletePatient(int patientid)
        {
            try
            {
                var patient = Context.Patients.Find(patientid);
                if (patient != null)
                {

                    Context.Patients.Remove(patient);
                    Context.SaveChanges();


                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            return Context.Appointments.ToList();
        }

        public List<Patient> GetAllPatients()
        {
            return Context.Patients.ToList();
        }

        public Appointment GetAppointmentByid(int appointmentid)
        {
            Appointment appointment = null;
            try
            {
                appointment = Context.Appointments.Find(appointmentid);

            }
            catch
            {
                return null;
            }
            return appointment;

        }

        public Patient GetPatientById(int patientid)
        {
            var res = Context.Patients
                     .Include(x => x.appointments)
                     .FirstOrDefault(x => x.PatientId==patientid);
                     //.Where(x => x.PatientId == patientid);
                    

            return res;
        }

        public bool UpdatePatient(Patient patient)
        {
            var existing = Context.Patients.Find(patient.PatientId);
            if (existing != null)
            {
                existing.PatientName = patient.PatientName;

                existing.PatientAge = patient.PatientAge;

                existing.ContactNo = patient.ContactNo;
                Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //public Patient GetPatientAppointmentsById(int id)
        //{
        //    try
        //    {
        //        var res = Context.Patients
        //             .Include(x => x.appointments)
        //             .Where(x => x.PatientId == id)
        //             .ToList();
                    
        //        return res;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}

