using HospitalData;
using HospitalData.Models;
using HospitalData.Repository;
using Microsoft.EntityFrameworkCore;
namespace HospitalApp
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Run();      

    }
        public  static void Run()
        {
            HospitalAppContext _context = new HospitalAppContext();

            HospitalRepository repository = new HospitalRepository(_context);
            repository.SeedDB();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose options :");
                Console.WriteLine("1. View doctor by Id (by different loading strategy)");
                Console.WriteLine("2.Search doctors by Specialty");
                Console.WriteLine("3.Search by patientname");
                Console.WriteLine("4. exit");
                Console.WriteLine("Enter option 1-4");
                var Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                         repository.LoadDoctorDetails();
                        break;

                    case "2":
                        repository.SearchBySpecialty();
                        break;


                    case "3":
                        repository.SearchByPatientName();
                        break;

                    case "4":
                        exit = true;
                        break;

                }

            }

        }
    }
}
