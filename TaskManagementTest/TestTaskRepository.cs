using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Controllers;
using TaskManagementDataAccess;
using TaskManagementDataAccess.DBModel;
using TaskManagementService;
using TaskManagementService.DTO;

namespace TaskManagementTest
{
    public class TestTaskRepository
    {
        [Test]
        public async Task GetDBData_ReturnData()
        {

            var mockSet = new Mock<DbSet<TaskModel>>();

            var mockContext = new Mock<TaskDBContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);

            var service = new TaskManagementRepoImplement(mockContext.Object);
            service.GetTasks();

            mockSet.Verify(m => m.Add(It.IsAny<TaskModel>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());


        }

    }
}
