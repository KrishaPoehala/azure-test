using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dz5Binary.UnitTests.Tests;

public class TasksTests
{
    [Fact]
    public void GetFinishedTasks_ReturnsValidData_WhenThereIsData()
    {
        var testData = new List<IdNameOnlyTaskDTO> { new() { RenamedName = "test" } };
        var serviceMock = new Mock<ITaskService>();
        serviceMock.Setup(s => s.GetFinishedTasks(2))
            .Returns(testData);
        var userController = new TaskController(serviceMock.Object);
        //Act
        var response = userController.GetFinishedTasks(2);
        var result = response.Result as OkObjectResult;
        var teamsInfo = result.Value as IEnumerable<IdNameOnlyTaskDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        serviceMock.Verify(x => x.GetFinishedTasks(2), Times.Once());
        Assert.Equal(teamsInfo, testData);
    }

    [Fact]
    public void GetFinishedTasks_ReturnsNoData_WhenThereIsNoData()
    {
        var testData = Enumerable.Empty<IdNameOnlyTaskDTO>();
        var serviceMock = new Mock<ITaskService>();
        serviceMock.Setup(s => s.GetFinishedTasks(2))
            .Returns(testData);
        var userController = new TaskController(serviceMock.Object);
        //Act
        var response = userController.GetFinishedTasks(2);
        var result = response.Result as OkObjectResult;
        var teamsInfo = result.Value as IEnumerable<IdNameOnlyTaskDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        serviceMock.Verify(x => x.GetFinishedTasks(2), Times.Once());
        Assert.Empty(teamsInfo);
    }

    [Fact]
    public void GetTasks_ReturnsValidData_WheneThereIsData()
    {
        //Arrange
        var testData = new List<TaskDTO> { new() { RenamedName = "test" } };
        var serviceMock = new Mock<ITaskService>();
        serviceMock.Setup(s => s.GetTasks(2))
            .Returns(testData);
        var userController = new TaskController(serviceMock.Object);
        //Act
        var response = userController.GetTasks(2);
        var result = response.Result as OkObjectResult;
        var teamsInfo = result.Value as IEnumerable<TaskDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        serviceMock.Verify(x => x.GetTasks(2), Times.Once());
        Assert.Equal(teamsInfo, testData);
    }

    [Fact]
    public void GetTasksCountByProject_ReturnsValidData_WhenThereIsData()
    {
        //Arrange
        var testData = new Dictionary<int, ProjectDTO>
        {
            {3, new() { Name = "test"} },
        };
        var serviceMock = new Mock<ITaskService>();
        serviceMock.Setup(s => s.GetTasksCountByProject(2))
            .Returns(testData);
        var userController = new TaskController(serviceMock.Object);
        //Act
        var response = userController.GetTasksCountByProject(2);
        var result = response.Result as OkObjectResult;
        var teamsInfo = result.Value as IDictionary<int, ProjectDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        serviceMock.Verify(x => x.GetTasksCountByProject(2), Times.Once());
        Assert.Equal(teamsInfo, testData);
    }

    [Theory]
    [InlineData(2)]
    public async Task FinishTask_FinishesTask_WhenItExists(int id)
    {
        //Arrange
        var mockService = new Mock<ITaskService>();
        mockService.Setup(x => x.FinishTask(id))
            .Verifiable();
        //Act
        var controller = new TaskController(mockService.Object);
        var response = await controller.FinishTask(id);
        var result = response as OkResult;
        //Assert
        Assert.True(result is not null);
        Assert.Equal(result.StatusCode, StatusCodes.Status200OK);
        mockService.Verify(x => x.FinishTask(id), Times.Once());
    }

    [Theory]
    [InlineData(2)]
    public async Task FinishTask_NotFound_WhenTheTaskNotFound(int id)
    {
        //Arrange
        var mockService = new Mock<ITaskService>();
        mockService.Setup(x => x.FinishTask(id))
            .ThrowsAsync(new NullReferenceException());
        //Act
        var controller = new TaskController(mockService.Object);
        var response = await controller.FinishTask(id);
        var result = response as NotFoundResult;
        //Assert
        Assert.True(result is not null);
        Assert.Equal(result.StatusCode, StatusCodes.Status404NotFound);
        mockService.Verify(x => x.FinishTask(id), Times.Once());
    }
}
