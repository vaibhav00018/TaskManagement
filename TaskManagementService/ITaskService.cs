using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementService.DTO;

namespace TaskManagementService
{
    public interface ITaskService
    {
        public Task<List<TaskDTO>> GetAllTasks();

        public Task<bool> UpdateTask(TaskDTO task);

        public Task<TaskDTO> AddTask(TaskDTO task);

        public Task<bool> DeleteTask(Guid taskId);
    }
}
