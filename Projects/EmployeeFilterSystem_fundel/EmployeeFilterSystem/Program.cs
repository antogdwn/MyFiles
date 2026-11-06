namespace EmployeeFilterSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            List<Employee> employees = new List<Employee>();
            //Employee empobj = new Employee();
            // employees.Add(new Employee(1, "Anto", "100000", "IT"));

            employees.Add(new Employee { id = 1, Name = "Anto", Salary = 100000, Department = "IT" });
            employees.Add(new Employee { id = 2, Name = "Godwin", Salary = 200000, Department = "IT" });
            employees.Add(new Employee { id = 3, Name = "test", Salary = 20000, Department = "Govt" });
            employees.Add(new Employee { id = 4, Name = "test", Salary = 2000001, Department = "Govt" });

            //Console.WriteLine(string.Join(",",employees));

            //Employee empobj=new Employee();
            var X=Employee.Filter(employees, emp => emp.Salary > 100000);
            var Y= Employee.Filter(employees, emp => emp.Department == "IT");

           Console.WriteLine(string.Join(",",(X.Select(x=>x.Name))));
            Console.WriteLine(string.Join(",",(Y.Select(y=>y.Name))));
            //foreach(string emp in X) {
        }
    }
}
