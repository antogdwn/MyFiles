using Microsoft.AspNetCore.Mvc;
using Mymvcapp_final.Models;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace Mymvcapp_final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Shift_Model> ShiftObjects = new List<Shift_Model>();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            
            return View();
        }

        [HttpPost]
        public ActionResult AddShift(Shift_Model shift)
        {
            if (!string.IsNullOrWhiteSpace(shift.LeaveDates))
            {
                shift.LeaveDate = shift.LeaveDates.Split(',').Select(int.Parse).ToList();
            }
            Shift_Model Shiftvalues = new Shift_Model()
            {
                EmployeeEnterpriseID = shift.EmployeeEnterpriseID,
                WBSElement = shift.WBSElement,
                StartDate = shift.StartDate.Date,
                EndDate = shift.EndDate.Date,
                LeaveDate = shift.LeaveDate
            };
            ShiftObjects.Add(Shiftvalues);
            ViewBag.Shift_obj = ShiftObjects;
            return View("Index");
        }
        [HttpPost]
        public IActionResult GenerateCSV()
        {

            // Create CSV content
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine($"\"Employee ID\",\"WBSE\",\"Start Date\",\" End Date \",\"Number of Days\",\"WeekdayDates\",\"Weekend Dates\",\"Total days worked\"");
            foreach (Shift_Model shift in ShiftObjects)
            {                             
                int totalDays = (int)(shift.EndDate.Date - shift.StartDate.Date).TotalDays + 1;  // Calculate total number of days
                ViewBag.Total_days = totalDays;
                List<int> weekdayDates = new List<int>();     // Calculate weekday and weekend dates
                List<int> weekendDates = new List<int>();
                for (int i = 0; i < totalDays; i++)
                {
                    DateTime currentDate = shift.StartDate.AddDays(i);
                    // Check if the current date is a weekday (Monday to Friday)
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        weekdayDates.Add(currentDate.Day);
                    }
                    else
                    {
                        weekendDates.Add(currentDate.Day);
                    }
                }
                if (shift.LeaveDate != null)
                {
                    foreach (int num in shift.LeaveDate)
                    {
                        weekdayDates.Remove(num);
                    }
                }
                int totalDaysWorked = weekdayDates.Count;
                // Append the data to the CSV content
                csvContent.AppendLine($"{shift.EmployeeEnterpriseID},{shift.WBSElement},{shift.StartDate:dd/MM/yy},{shift.EndDate:dd/MM/yy},{totalDays},\"{string.Join(",", weekdayDates)}\",\"{string.Join(",", weekendDates)}\",{totalDaysWorked}");
            }
            string csvFileName = $"ShiftAllowanceReport{DateTime.Now:dd-MM-yy}.csv";
            string csvFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", csvFileName);
            System.IO.File.WriteAllText(csvFilePath, csvContent.ToString());
            return PhysicalFile(csvFilePath, "text/csv", csvFileName);

        }
        [HttpPost]
        public IActionResult ClearAllShifts()
        {
            // Handle the logic to clear all shifts
            ShiftObjects.Clear();
            return View("Index");
        }

    }  
}
