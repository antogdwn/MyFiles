using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFilterSystem
{
    internal class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        //public Employee(int id,string Name,double Salary,string Department) {
        //    this.id = id;
        //    this.Name= Name;
        //    this.Salary= Salary;
        //    this.Department= Department;       
        //}

        public static List<Employee> Filter(List<Employee> employees, Func<Employee, bool>condition)
        {
            return employees.Where(condition).ToList();

        }

    }
}
