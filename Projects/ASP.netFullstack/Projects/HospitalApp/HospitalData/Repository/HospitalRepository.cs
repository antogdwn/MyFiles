using HospitalData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalData.Repository
{
    public class HospitalRepository
    {
         HospitalAppContext context;
        public HospitalRepository( HospitalAppContext appcontext) {

            this.context = appcontext;
        }
        public   void LoadDoctorDetails()
        {
            Console.WriteLine("Choose options for Loading Strategy 1 : Eager, 2: Lazy , 3: Explicit");

            var Choice = Console.ReadLine();

            Console.WriteLine("Enter Doc id");
            var Doctorid =Convert.ToInt32(Console.ReadLine());
            Doctor doctor = null;

            switch (Choice)
            {
                case "1":
                     doctor =  context.Doctors.Include(d => d.Patients).FirstOrDefault(d => d.DoctorId == Doctorid);
                    
                    break;
                case "2":
                     doctor =  context.Doctors.FirstOrDefault(d => d.DoctorId == Doctorid);
                    break;
                case "3":
                    doctor = context.Doctors.FirstOrDefault(d=>d.DoctorId==Doctorid);
                    if(doctor != null)
                    {
                        context.Entry(doctor).Collection(d=>d.Patients).Load();
                    }
                    break;




            }
            Console.WriteLine($"DoctorId :{doctor.DoctorId},DoctorName :{doctor.Name},DoctorSpecialty:{doctor.Specialty} ");
            
        }

        public  void SearchBySpecialty()
        {
            var Doctor = new Doctor();
            Console.WriteLine("Enter specialty name");
            var SpecialtyName = Console.ReadLine();

            var Res = context.Doctors.Where(d=>d.Specialty.Contains(SpecialtyName)).ToList();

            foreach(var doc in Res)
            {
                Console.WriteLine($"DoctorName :{doc.Name},DoctorSpecialty :{doc.Specialty} {doc.Patients}");
            }

        }

        public  void SearchByPatientName()
        {
            var Doctor = new Patient();
            Console.WriteLine("Enter Patient name");
            var PatientName = Console.ReadLine();

            var Res = context.Patients.Where(d => d.PatientName.Contains(PatientName)).Include(p=>p.Doctor).ToList();

            foreach (var doc in Res)
            {
                Console.WriteLine($"PatientName :{doc.PatientName},Address :{doc.Address} {doc.Age}, Doctor : {doc.Doctor.Name}");
            }
        }




        public  void SeedDB()
        {
            if (context.Doctors.Any())
            {
                return;
            }
            //have validation before insert and also declare new instance of doctor and then add using Addrange
            context.Doctors.AddAsync(new Doctor
            {
                Name = "DR.Anto",
                Specialty = "Medicine",
                Patients = new[] { new Patient { PatientName = "Bharath", Age = 25, Address = "HomeAddress,5th street,6000001" },
                                                             new Patient { PatientName = "Mandu", Age = 20, Address = "Jannatpg" } }
            });

            context.Doctors.AddAsync(new HospitalData.Models.Doctor { Name = "DR.Mansi", Specialty = "Medicine", Patients = new[] { new Patient { PatientName = "Ando", Age = 25, Address = "HomeAddress,5th street,6000001" } } });

            context.SaveChanges();
        }
    }
}

