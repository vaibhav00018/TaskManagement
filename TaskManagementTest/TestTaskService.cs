using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Controllers;
using TaskManagementDataAccess;
using TaskManagementDataAccess.DBModel;
using TaskManagementService;
using TaskManagementService.DTO;

namespace TaskManagementTest
{
    public class TestTaskService
    {
        private Mock<ITaskManagementRepo> _taskRepo;
        private TaskService _taskService;

        [SetUp]
        public void Setup()
        {
            _taskRepo = new Mock<ITaskManagementRepo>();
            _taskService = new TaskService(_taskRepo.Object);
        }

        [Test]
        public async Task GetTask_ValidTask_ReturnsTaskDTO()
        {
            // Arrange
            List<TaskModel> list = new List<TaskModel>();
            list.Add(new TaskModel { Id = new Guid(), Description = "ABC", Name = "ABC", Status = "TODO" });

            List<TaskDTO> DTOlist = new List<TaskDTO>();
            DTOlist.Add(new TaskDTO { Id = new Guid(), Description = "ABC", Name = "ABC" });

            _taskRepo.Setup(service => service.GetTasks()).ReturnsAsync(list);


            // Act
            var result = await _taskService.GetAllTasks();

            //Assets
            Assert.AreEqual(DTOlist[0].Id, result[0].Id);
            Assert.AreEqual(DTOlist[0].Name, result[0].Name);

        }
    }
}
