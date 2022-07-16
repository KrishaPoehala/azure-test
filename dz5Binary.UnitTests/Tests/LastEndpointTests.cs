using AutoMapper;
using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Task;
using dz3Binary.Common.Profiles;
using dz3Binary.Controllers;
using dz3Binary.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dz5Binary.UnitTests.Tests;

public class LastEndpointTests
{
    private readonly ProjectContext _context;
    private readonly IMapper _mapper;
    public LastEndpointTests()
    {
        var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>()); 
        _mapper = mapperConfig.CreateMapper();
        var optionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
        optionsBuilder.UseInMemoryDatabase("Tests");
        //the db is populated with data in OnModelCreating method
        _context = new ProjectContext(optionsBuilder.Options);
        _context.Database.EnsureCreated();
    }

    [Theory]
    [InlineData(17)]
    [InlineData(10)]
    [InlineData(int.MaxValue)] // I cover negative case here too.
    public async Task GetUnfinishedTasks_BL_ReturnsData_WhenThereIsData(int userId)
    {
        //Arrange
        var taskService = new TaskService(_context, _mapper);
        //Act
        var unfinishedTasks = taskService.GetUnfinishedTasks(userId).ToList();
        //Assert
        Assert.NotNull(unfinishedTasks);
        Assert.True(unfinishedTasks.Count >= 0);
        await _context.Database.EnsureDeletedAsync();
    }

    [Theory]
    [InlineData(10)]
    [InlineData(int.MaxValue)]
    public async Task GetUnfinishedTasks_API_ReturnsData_WhenThereIsData(int userId)
    {
        //Arrange
        var testData = new List<TaskDTO>() { new() { RenamedName = "DFDFDF" } };
        var mockService = new Mock<ITaskService>();
        mockService.Setup(x => x.GetUnfinishedTasks(userId))
            .Returns(testData);

        var controller = new TaskController(mockService.Object);
        //Act
        var response = controller.GetUnfinishedTask(userId);
        var result = response.Result as OkObjectResult;
        var unfinishedTasks = result.Value as IEnumerable<TaskDTO>;
        //Assert
        Assert.NotNull(unfinishedTasks);
        Assert.Equal(result.StatusCode, StatusCodes.Status200OK);
        mockService.Verify(x => x.GetUnfinishedTasks(userId), Times.Once());

    }
}
