using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Application.Interfaces;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _appDbContext;

        public TaskService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void CreateTask(TaskItem item, string userid)
        {
            if (item != null)
            {
                item.UserId = userid;
                _appDbContext.Tasks.Add(item);
                _appDbContext.SaveChanges();
            }
        }

        public void  DeleteTask(int ID,string userid)
        {
            var task = _appDbContext.Tasks.FirstOrDefault(t => t.UserId == userid && t.Id == ID);
            if (task != null) 
            { 
                _appDbContext.Remove(task);
                _appDbContext.SaveChanges();

            }
        }

        public List<TaskItem> GetAllTaskItemsForUser(string userId)
        {
            var tasks = _appDbContext.Tasks.Where(t => t.UserId == userId).ToList();
            return tasks;
        }

        public TaskItem GetTaskItemByID(int ID, string userid)
        {
            var tasks = _appDbContext.Tasks.Where(t => t.Id == ID).Where(t => t.UserId == userid).FirstOrDefault();
            return tasks;
        }

        public void UpdateTask(TaskItem item, string userid)
        {

            var updatetask = _appDbContext.Tasks.FirstOrDefault(t => t.UserId == userid && t.Id == item.Id);
            if (updatetask != null)
            {
                if (item.Title != null)
                {
                    updatetask.Title = item.Title;
                }
                if (item.Description != null)
                {
                    updatetask.Description = item.Description;
                }

                updatetask.IsCompleted = item.IsCompleted;
                updatetask.Duedate = item.Duedate;
            }
            _appDbContext.SaveChanges();
        }
    }
}
