using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace dz5Binary.UnitTests.Tests;

public class ProjectsTests
{
    [Fact]
    public void GetProjectInfo_ReturnsValidData_WhenThereIsData()
    {
        //Arrange
        var testData = new List<ProjectTasksInfoDTO> { new() { UsersCount = 1 } };
        var serviceMock = new Mock<IProjectService>();
        serviceMock.Setup(s => s.GetProjectInfo())
            .Returns(testData);
        var userController = new ProjectController(serviceMock.Object);
        //Act
        var response = userController.GetProjectInfo();
        var result = response.Result as OkObjectResult;
        var teamsInfo = result.Value as IEnumerable<ProjectTasksInfoDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        serviceMock.Verify(x => x.GetProjectInfo(), Times.Once());
        Assert.Equal(teamsInfo, testData);
    }
}
