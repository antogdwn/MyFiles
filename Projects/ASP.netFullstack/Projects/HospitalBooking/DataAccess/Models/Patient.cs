using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public  class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PatientAge {  get; set; }
        public string ContactNo { get; set; }

        public List<Appointment> appointments { get; set; } = new List<Appointment>();

    }
}
