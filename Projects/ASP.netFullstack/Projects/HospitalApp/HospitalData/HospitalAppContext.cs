using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalData.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalData
{
    public  class HospitalAppContext :DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=CDC2-L-4033793;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True;").UseLazyLoadingProxies();
            
        }

    }
}
