using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.Application.Interfaces
{
    public interface ITaskService
    {
        List<TaskItem> GetAllTaskItemsForUser(string UserId);

        TaskItem GetTaskItemByID(int ID,string userId);

         void CreateTask(TaskItem item,string userid);

        void UpdateTask(TaskItem item,string userid);

        void DeleteTask(int ID,string UserId);
    }
}
