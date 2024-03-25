using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementService;
using Moq;
using TaskManagement.Controllers;
using TaskManagementService.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementTest
{
    public class TestTaskController
    {
        private Mock<ITaskService> _taskService;
        private TaskController _controller;

        [SetUp]
        public void Setup()
        {
            _taskService = new Mock<ITaskService>();    
            _controller = new TaskController(_taskService.Object);
        }


        [Test]
        public void GetTask_ValidTask_ReturnsCreatedTask()
        {
            // Arrange
            TaskDTO task = new TaskDTO { Id = Guid.NewGuid(), Description = "ABC", Name = "ABC" };
            List<TaskDTO> list = new List<TaskDTO>();
            list.Add(task);
            _taskService.Setup(service => service.GetAllTasks()).ReturnsAsync(list);


            // Act
             var result = _controller.GetTask();

            //Assets
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(list, okResult.Value);
        }
    }
}
