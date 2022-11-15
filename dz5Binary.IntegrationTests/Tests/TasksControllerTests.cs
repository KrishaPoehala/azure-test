using dz3Binary;
using dz3Binary.Common.DTO.Task;
using dz5Binary.IntegrationTests.CustomFactories;
using dz6Binary;
using FluentAssertions;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace dz5Binary.IntegrationTests.Tests;

public class TasksControllerTests :
    IntegrationTestsBase,
    IClassFixture<CustomWebApplicationFactory<Startup>>
{
    public TasksControllerTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async Task DeleteTask_DeletesATask_WhenItExists()
    {
        //Arrange
        var taskToDelete = await (await _client.GetAsync("api/task/getFirst"))
           .Content.ReadFromJsonAsync<TaskDTO>();
        // Act
        var response = await _client.DeleteAsync("api/task/delete/" + taskToDelete.Id);
        var deletedTask = await response.Content.ReadFromJsonAsync<TaskDTO>();
        // Assert
        deletedTask.Id.Should().Be(taskToDelete.Id);
    }

    [Fact]
    public async Task DeleteTask_NotFound_WhenItDoesNotExist()
    {
        // Act
        var response = await _client.DeleteAsync("api/task/delete/" + int.MaxValue);
        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }


}
