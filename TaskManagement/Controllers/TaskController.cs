using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManagementService;
using TaskManagementService.DTO;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        public readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Route("gettask")]
        [HttpGet]
        [ProducesResponseType(typeof(List<TaskDTO>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetTask()
        {
            try
            {
                var response = await _taskService.GetAllTasks();
                return StatusCode(201, response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("addtask")]
        [HttpPost]
        [ProducesResponseType(typeof(List<TaskDTO>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> AddTask(TaskDTO task)
        {
            try
            {
                var response = await _taskService.AddTask(task);
                return StatusCode(201, response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("updatetask")]
        [HttpPut]
        [ProducesResponseType(typeof(List<TaskDTO>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> UpdateTask(TaskDTO task)
        {
            try
            {
                var response = await _taskService.UpdateTask(task);
                return StatusCode(200, response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("deletetask")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            try
            {
                var response = await _taskService.DeleteTask(taskId);
                return StatusCode(200, response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
