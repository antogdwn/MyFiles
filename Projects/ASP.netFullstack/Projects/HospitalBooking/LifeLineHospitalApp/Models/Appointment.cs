using System.ComponentModel.DataAnnotations;
namespace LifeLineHospitalApp.Models
{
    public class Appointment
    {

        public int AppointmentId { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }
    }
}
