using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.User;
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

public class UsersTests
{
    [Fact]
    public void GetSortedUsers_GetsValidData_WhenThereIsData()
    {
        //Arrange
        var testData = new List<UserDTO>() { new() { FirstName = "testName"} };
        var serviceMock = new Mock<IUserService>();
        serviceMock.Setup(s => s.GetSortedUsers())
            .Returns(testData);

        var controller = new UserController(serviceMock.Object);
        //Act
        var response = controller.GetSortedUsers();
        //Cannot use response.Value(it is set by asp.net core or something like that :D)
        //https://stackoverflow.com/questions/51489111/how-to-unit-test-with-actionresultt
        var result = response.Result as OkObjectResult;
        var users = result.Value as IEnumerable<UserDTO>;
        //Assert
        Assert.True(result is OkObjectResult);
        serviceMock.Verify(r => r.GetSortedUsers());
        Assert.Equal(testData, users.ToList());
    }

    [Fact]
    public void GetSortedUsers_ReturnsNoData_WhenThereIsNoData()
    {
        //Arrange
        var testData = Enumerable.Empty<UserDTO>();
        var serviceMock = new Mock<IUserService>();
        serviceMock.Setup(s => s.GetSortedUsers())
            .Returns(testData);

        var controller = new UserController(serviceMock.Object);
        //Act
        var response = controller.GetSortedUsers();
        var result = response.Result as OkObjectResult;
        var data = result.Value as IEnumerable<UserDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        Assert.Empty(data);
        serviceMock.Verify(x => x.GetSortedUsers(), Times.Once());
    }

    [Fact]
    public void GetTasksInfo_GetsValidData()
    {
        //Arrange
        var testData = new List<UserTasksInfoDTO> { new() { TasksCount = 1 } };
        var serviceMock = new Mock<IUserService>();
        serviceMock.Setup(s => s.GetTasksInfo(2))
            .Returns(testData);
        var userController = new UserController(serviceMock.Object);
        //Act
        var response = userController.GetTasksInfo(2);
        var result = response.Result as OkObjectResult;
        var tasksInfo = result.Value as IEnumerable<UserTasksInfoDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        serviceMock.Verify(x => x.GetTasksInfo(2), Times.Once());
        Assert.Equal(tasksInfo.ToList(), testData);
    }

    [Fact]
    public void GetTasksInfo_ReturnsNoData_WhenThereIsNoData()
    {
        //Arrange
        var testData = Enumerable.Empty<UserTasksInfoDTO>();
        var serviceMock = new Mock<IUserService>();
        serviceMock.Setup(s => s.GetTasksInfo(2))
            .Returns(testData);
        var userController = new UserController(serviceMock.Object);
        //Act
        var response = userController.GetTasksInfo(2);
        var result = response.Result as OkObjectResult;
        var tasksInfo = result.Value as IEnumerable<UserTasksInfoDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        serviceMock.Verify(x => x.GetTasksInfo(2));
        Assert.Empty(tasksInfo);
    }

    [Theory]
    [InlineData("testName")]
    public async Task CreateUser_CreatesAUser_WhenDataIsValid(string firstName)
    {
        //Arrange
        var newUserdto = new NewUserDTO() { FirstName = firstName };
        var mockService = new Mock<IUserService>();
        mockService.Setup(x => x.CreateUser(newUserdto))
            .Verifiable();

        var controller = new UserController(mockService.Object);
        //Act
        var response = await controller.PostUser(newUserdto);
        var result = response.Result as CreatedResult;
        var createdUser = result.Value as UserDTO;
        //Assert
        Assert.True(response.Result is CreatedResult);
        mockService.Verify(x => x.CreateUser(newUserdto), Times.Once());
    }

    [Fact]
    public async Task CreateUser_ReturnsBadRequst_WhenDataIsNotValid()
    {
        //Arrange
        NewUserDTO newUserDto = null;  
        var mockService = new Mock<IUserService>();
        mockService.Setup(x => x.CreateUser(newUserDto))
            .ThrowsAsync(new NullReferenceException());

        var controller = new UserController(mockService.Object);
        //Act
        var response = await controller.PostUser(newUserDto);
        var result = response.Result as BadRequestResult;
        //Assert
        Assert.True(result is not null);
        Assert.Equal(result.StatusCode, StatusCodes.Status400BadRequest);
        
        
    }

}
