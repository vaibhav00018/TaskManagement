using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDataAccess;
using TaskManagementDataAccess.DBModel;
using TaskManagementService.DTO;

namespace TaskManagementService
{
    public class TaskService : ITaskService
    {
        public ITaskManagementRepo _taskRepo;
        public TaskService(ITaskManagementRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

        /// <summary>
        /// Get all the task.
        /// </summary>
        /// <returns>list of task</returns>
        public async Task<List<TaskDTO>> GetAllTasks()
        {
            var taskDBList = await _taskRepo.GetTasks();
            List<TaskDTO> tasks = new List<TaskDTO>();

            foreach (var item in taskDBList)
            {
                TaskDTO task = new TaskDTO
                {
                    Id = item.Id,
                    Description = item.Description,
                    Name = item.Name,
                    IsFavorite = item.IsFavorite == 0 ? false : true,
                    LastUpdated = item.LastUpdated,
                    LoggedTime = item.LoggedTime,
                    Status = (TaskStatusEnum)Enum.Parse(typeof(TaskStatusEnum), item.Status, true),
                    ImagesUrls = item.ImagesUrls?.Split('_')
                };

                tasks.Add(task);
            }

            tasks.OrderBy(x=>x.IsFavorite ? 0 : 1);
            return tasks;
        }

        /// <summary>
        /// To Delete the task
        /// </summary>
        /// <param name="taskId">Unique Id for each task</param>
        /// <returns>Will return true if delete succeed</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteTask(Guid taskId)
        {
            var isSucceed = await _taskRepo.DeleteTask(taskId);
            return isSucceed;
        }

        /// <summary>
        /// To add or update the existing task
        /// </summary>
        /// <param name="task">DTO for the task</param>
        /// <returns>should return the success DTO</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TaskDTO> AddTask(TaskDTO task)
        {
            TaskModel taskModel = new TaskModel
            {
                Id = Guid.NewGuid(),
                Description = task.Description,
                Name = task.Name,
                IsFavorite = task.IsFavorite == false ? (byte)0 : (byte)1,
                LastUpdated = DateTime.Now,
                LoggedTime = DateTime.Now,
                Status = task.Status.ToString(),
                ImagesUrls = string.Join("_", task.ImagesUrls)
            };

            var response = await _taskRepo.AddTask(taskModel);
            return task;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task<bool> UpdateTask(TaskDTO task)
        {
            TaskModel taskModel = new TaskModel
            {
                Id = task.Id,
                Description = task.Description,
                Name = task.Name,
                IsFavorite = task.IsFavorite == false ? (byte)0 : (byte)1,
                LastUpdated = DateTime.Now,
                Status = task.Status.ToString(),
                ImagesUrls = string.Join("_", task.ImagesUrls)
            };

            await _taskRepo.UpdateTask(taskModel, task.Id);
            return true;
        }
    }
}
