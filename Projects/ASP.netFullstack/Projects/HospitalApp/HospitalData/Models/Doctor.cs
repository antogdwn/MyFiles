using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalData.Models
{
    public  class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }

        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    }
}
