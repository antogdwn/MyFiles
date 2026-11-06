using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Mymvcapp_final.Models
{
    public class Shift_Model
    {
        public required String EmployeeEnterpriseID { get; set; }
        public required string WBSElement { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public  List<int>? LeaveDate { get; set; } 
        public String LeaveDates { get; set; }
    }

}
