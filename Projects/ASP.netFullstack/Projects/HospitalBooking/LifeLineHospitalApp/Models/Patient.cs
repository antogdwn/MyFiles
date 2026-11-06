using System.ComponentModel.DataAnnotations;
namespace LifeLineHospitalApp.Models
{
    public class Patient
    {
        
        [Key] 
        public int PatientId { get; set; }
        [Required]
        [MinLength(4,ErrorMessage ="Length must be minimum of 4 ")]
        public string PatientName { get; set; }

        public int PatientAge { get; set; }
        [Phone]
        public string ContactNo { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
