using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDataAccess.DBModel;

namespace TaskManagementDataAccess
{
    public class TaskManagementRepoImplement : ITaskManagementRepo
    {
        private readonly TaskDBContext _context;


        public TaskManagementRepoImplement(TaskDBContext context)
        {
            _context = context;
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _context.Tasks.AddAsync(task);

            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(Guid taskId)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == taskId);

            if (task == null)
            {
                return false;
            }

            _context.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            List<TaskModel> tasks = new List<TaskModel>();

            tasks = await _context.Tasks.Select(x => x).ToListAsync();

            return tasks;
        }

        public async Task<bool> UpdateTask(TaskModel task, Guid id)
        {
            var data = await _context.Tasks.FindAsync(id);
            if (data == null)
            {
                return false;
            }
            data.Status = task.Status;
            data.IsFavorite = task.IsFavorite; 
            data.LastUpdated = task.LastUpdated;
            data.Description = task.Description;
            data.ImagesUrls = task.ImagesUrls;
            data.Name = task.Name;
            data.Status = task.Status;

            _context.Tasks.Update(data);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
