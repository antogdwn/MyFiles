using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalData.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
         

    }
}
