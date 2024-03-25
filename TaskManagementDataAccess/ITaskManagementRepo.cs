using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDataAccess.DBModel;

namespace TaskManagementDataAccess
{
    public interface ITaskManagementRepo
    {
        public Task<List<TaskModel>> GetTasks();

        public Task<Boolean> UpdateTask(TaskModel task, Guid id);

        public Task<TaskModel> AddTask(TaskModel task);

        public Task<Boolean> DeleteTask(Guid taskId);
    }
}
