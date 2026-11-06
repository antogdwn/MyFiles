using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerr
{
    public class TaskManager
    {

        static List<Taskitems> TaskList = new();

        public static void Add_Task(Taskitems taskitems)
        {
            Console.WriteLine("Adding Tasks");

            TaskList.Add(taskitems);

            Console.WriteLine($"Task Added successfully  Task ID : {taskitems.Id} and Task Title : {taskitems.Title}");

        }

        public static void ViewALLTask()
        {
            foreach (var taskitems in TaskList)
            {
                Console.WriteLine("---------------");
                Console.WriteLine($"ID: {taskitems.Id}");
                Console.WriteLine($"Title: {taskitems.Title}");
                Console.WriteLine($"Description: {taskitems.Description}");
                Console.WriteLine($"Due Date: {taskitems.DueDate}");
                Console.WriteLine($"Priority: {taskitems.Priority}");
                Console.WriteLine($"Status: {taskitems.Status}");
                Console.WriteLine("---------------\n");
            }
        }

        public static void EditTask(int Taskid)
        {
            var taskToEdit = TaskList.FirstOrDefault(t => t.Id == Taskid);

            if (taskToEdit != null) 
            {
                Console.WriteLine("Task found! Enter new details:");

                Console.WriteLine("Enter New title");
                taskToEdit.Title = Console.ReadLine();

                Console.WriteLine("Enter New Description");
                taskToEdit.Description = Console.ReadLine();


                Console.WriteLine("Enter New due date");
                string Due_Date = Console.ReadLine(); 
                taskToEdit.DueDate = DateTime.Parse(Due_Date);

                Console.WriteLine("Enter New status");
                taskToEdit.Status = Console.ReadLine();

                Console.WriteLine("Task updated successfully ");

            }
            else
            {
                Console.WriteLine("task not found");
            }

        }

        public static void DeleteTask(int Taskid)
        {
            var taskTodelete = TaskList.FirstOrDefault(t => t.Id == Taskid);
            if (taskTodelete != null) 
            {
                bool Isdelete = TaskList.Remove(taskTodelete);
                Console.WriteLine("Task removed successfully");
            }
        }

        public static void CompleteTask(int Taskid)
        {
            var Tasktocomplete = TaskList.FirstOrDefault(t => t.Id == Taskid);
            if (Tasktocomplete != null)
            {

                Tasktocomplete.Status = "Completed";            
                Console.WriteLine("Task Completed ");

                Console.WriteLine("Updated task details");
                Console.WriteLine("---------------");
                Console.WriteLine($"ID: {Tasktocomplete.Id}");
                Console.WriteLine($"Title: {Tasktocomplete.Title}");
                Console.WriteLine($"Description: {Tasktocomplete.Description}");
                Console.WriteLine($"Due Date: {Tasktocomplete.DueDate}");
                Console.WriteLine($"Priority: {Tasktocomplete.Priority}");
                Console.WriteLine($"Status: {Tasktocomplete.Status}");
                Console.WriteLine("---------------\n");

            }
        }
        
        //Filter by status (Pending/Completed), Priority, or DueDate.
        public static void FilterTask(string statustype, string statuscat) 
        {

            if (statustype.Equals("Status", StringComparison.OrdinalIgnoreCase) && statuscat.Equals("Pending",StringComparison.OrdinalIgnoreCase)) 
            {
                var Filterresult = TaskList.Where(task => task.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase)).ToList();

                foreach (var filterresult in Filterresult) 
                {
                    Console.WriteLine($"Filtered task list ID {filterresult.Id}, Title {filterresult.Title}  , status  {filterresult.Status}");
                
                }
            }

            if (statustype.Equals("Status", StringComparison.OrdinalIgnoreCase) && statuscat.Equals("Completed",StringComparison.OrdinalIgnoreCase))
            {
                var Filterresult = TaskList.Where(task => task.Status.Equals("completed", StringComparison.OrdinalIgnoreCase)).ToList();

                foreach (var filterresult in Filterresult)
                {
                    Console.WriteLine($"Filtered task list ID {filterresult.Id}, Title {filterresult.Title}  , status  {filterresult.Status}");

                }
            }

            if (statustype.Equals("Status", StringComparison.OrdinalIgnoreCase) && statuscat.Equals("Started",StringComparison.OrdinalIgnoreCase))
            {
                var Filterresult = TaskList.Where(task => task.Status.Equals("started", StringComparison.OrdinalIgnoreCase)).ToList();

                foreach (var filterresult in Filterresult)
                {
                    Console.WriteLine($"Filtered task list ID {filterresult.Id}, Title {filterresult.Title} , status {filterresult.Status}");

                }
            }

            if (statustype.Equals("Priority",StringComparison.OrdinalIgnoreCase) && statuscat.Equals("Low", StringComparison.OrdinalIgnoreCase))
            {
                var Filterresult = TaskList.Where(task => task.Priority.Equals("Low", StringComparison.OrdinalIgnoreCase)).ToList();

                foreach (var filterresult in Filterresult)
                {
                    Console.WriteLine($"Filtered task list ID {filterresult.Id}, Title {filterresult.Title} , status {filterresult.Status}");

                }
            }

            if (statustype.Equals("Priority",StringComparison.OrdinalIgnoreCase) && statuscat.Equals("High",StringComparison.OrdinalIgnoreCase))
            {
                var Filterresult = TaskList.Where(task => task.Priority.Equals("Low", StringComparison.OrdinalIgnoreCase)).ToList();

                foreach (var filterresult in Filterresult)
                {
                    Console.WriteLine($"Filtered task list ID {filterresult.Id}, Title {filterresult.Title} , status {filterresult.Status}");

                }
            }          
        }
    }
}