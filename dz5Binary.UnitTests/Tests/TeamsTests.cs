using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Team;
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

public class TeamsTests
{
    [Fact]
    public void GetTeamInfo_ReturnsValidData_WhenThereIsData()
    {
        //Arrange
        var testData = new List<IdNameMembersOnlyTeamDTO> { new() { Name = "test" } };
        var serviceMock = new Mock<ITeamService>();
        serviceMock.Setup(s => s.GetTeamInfo())
            .Returns(testData);
        var userController = new TeamController(serviceMock.Object);
        //Act
        var response = userController.GetTeamInfo();
        var result = response.Result as OkObjectResult;
        var teamsInfo = result.Value as IEnumerable<IdNameMembersOnlyTeamDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        serviceMock.Verify(x => x.GetTeamInfo(),Times.Once());
        Assert.Equal(teamsInfo, testData);
    }

    [Fact]
    public void GetTeamInfo_ReturnsNoData_WhenThereIsNoData()
    {
        //Arrange
        var testData = Enumerable.Empty<IdNameMembersOnlyTeamDTO>();
        var serviceMock = new Mock<ITeamService>();
        serviceMock.Setup(s => s.GetTeamInfo())
            .Returns(testData);
        var userController = new TeamController(serviceMock.Object);
        //Act
        var response = userController.GetTeamInfo();
        var result = response.Result as OkObjectResult;
        var teamsInfo = result.Value as IEnumerable<IdNameMembersOnlyTeamDTO>;
        //Assert
        Assert.True(response.Result is OkObjectResult);
        serviceMock.Verify(x => x.GetTeamInfo(), Times.Once());
        Assert.Empty(teamsInfo);
    }

    [Theory]
    [InlineData(2)]
    public async Task AddMember_AddesAMember_WhenDataIdValid(int id)
    {
        var userDto = new UserDTO() { Email = "FDFDFDF" };
        //Arrange
        var mockService = new Mock<ITeamService>();
        mockService.Setup(x => x.AddMember(userDto, id))
            .Verifiable();

        var controller = new TeamController(mockService.Object);
        //Act
        var response = await controller.AddMember(userDto, id);
        var result = response as OkResult;
        //Assert
        Assert.True(result is OkResult);
        mockService.Verify(x => x.AddMember(userDto, id), Times.Once());
    }

    [Theory]
    [InlineData(2)]
    public async Task AddMember_BadRequest_WhenDataIsNotValid(int id)
    {
        var userDto = new UserDTO() { Email = "FDFDFDF" };
        //Arrange
        var mockService = new Mock<ITeamService>();
        mockService.Setup(x => x.AddMember(userDto, id))
            .ThrowsAsync(new NullReferenceException());

        var controller = new TeamController(mockService.Object);
        //Act
        var response = await controller.AddMember(userDto, id);
        var result = response as BadRequestResult;
        //Assert
        Assert.True(result is not null);
        Assert.Equal(result.StatusCode, StatusCodes.Status400BadRequest);
        mockService.Verify(x => x.AddMember(userDto, id), Times.Once());
    }



}
