using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskManagerr;

class TaskClass
{
    TaskManager taskManager = new();
    static void Main(string[] args)
    {

        bool running = true;
        while (running)
        {
            Console.WriteLine("Hello Welcome , Choose an option below on your tasklist");
            Console.WriteLine("1 . Add ");
            Console.WriteLine("2 . View All ");
            Console.WriteLine("3 . Edit task ");
            Console.WriteLine("4 . delete task ");
            Console.WriteLine("5 . Complete task ");
            Console.WriteLine("6 . Filter tasks");
            Console.WriteLine("7 . Exit ");


            string Input_ = Console.ReadLine();


            if (Input_ == "1")
            {
                Console.WriteLine("Enter the below details");
                Console.WriteLine("Enter ID ");
                int ID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Task title");
                string Task_title = Console.ReadLine();

                Console.WriteLine("Enter Task Description");
                string Description = Console.ReadLine();

                Console.WriteLine("Enter Task duedate");

                string Due_date = Console.ReadLine();
                DateTime Due_Date = DateTime.Parse(Due_date);

                Console.WriteLine("Enter Task priority");
                string priority = Console.ReadLine();


                Console.WriteLine("Enter Task status");
                string status = Console.ReadLine();

                Console.WriteLine("Inputs successful");


                Taskitems task = new()
                {
                    Id = ID,
                    Title = Task_title,
                    Description = Description,
                    DueDate = Due_Date,
                    Priority = priority,
                    Status = status
                };

                //TaskManager taskManager = new();
                TaskManager.Add_Task(task);

            }
            if (Input_ == "2")
            {

                TaskManager.ViewALLTask();
                Main(args);

            }
            if (Input_ == "3")
            {
                Console.WriteLine("Enter Task ID to edit : ");
                int Edit_id = Convert.ToInt32(Console.ReadLine());
                TaskManager.EditTask(Edit_id);
                Main(args);
            }
            if (Input_ == "4")
            {
                Console.WriteLine("Enter Task ID to delete : ");
                int taskid_del = Convert.ToInt32(Console.ReadLine());
                TaskManager.DeleteTask(taskid_del);
                Main(args);
            }
            if (Input_ == "5")
            {
                Console.WriteLine("Enter completed task id ");
                int Taskid_ = Convert.ToInt32(Console.ReadLine());
                TaskManager.CompleteTask(Taskid_);
                Main(args);
            }
            if (Input_ == "6")
            {
                Console.WriteLine("Enter Filter By");
                string FilterType = Console.ReadLine();
                Console.WriteLine("Enter Filter category");
                string Filtercat = Console.ReadLine();
                var myobj = new TaskClass();
                myobj.FilterTask(FilterType, Filtercat);

            }
            if(Input_ == "7") 
            {
                Console.WriteLine("Exiting,.");
                running = false;
            }


        }
    }
    public void FilterTask(String FilterType, string Filtercat)
    {
        if (FilterType.Equals("Status",StringComparison.OrdinalIgnoreCase))  //"DueDate", StringComparison.OrdinalIgnoreCase
        {
            TaskManager.FilterTask(FilterType, Filtercat);
        }

        if (FilterType.Equals("Priority",StringComparison.OrdinalIgnoreCase)) 
        {
            TaskManager.FilterTask(FilterType, Filtercat);
        }

        

    }

}