using dz3Binary;
using dz3Binary.Common.DTO.Project;
using dz5Binary.IntegrationTests.CustomFactories;
using dz6Binary;
using FluentAssertions;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace dz5Binary.IntegrationTests.Tests;

public class ProjectsControllerTests :
    IntegrationTestsBase,
    IClassFixture<CustomWebApplicationFactory<Startup>>
{
    public ProjectsControllerTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async Task CreateProject_CreatesAUserWhenDataIsValid()
    {
        //Arrange
        var newProject = new NewProjectDTO() { Name = "justCreated" };
        var createdProject = await (await _client.PostAsJsonAsync("api/project/create", newProject))
            .Content.ReadFromJsonAsync<ProjectDTO>();
        //Act
        var response = await _client.GetAsync("api/project/" + createdProject.Id);
        var returnedProject = await response.Content.ReadFromJsonAsync<ProjectDTO>();
        //Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        returnedProject.Id.Should().Be(createdProject.Id);
        returnedProject.Name.Should().Be(createdProject.Name);
    }

    [Fact]
    public async Task CreateProject_BadRequest_IfDataIsInvalid()
    {
        //Arrange
        NewProjectDTO newProject = null;
        var createdProject = await _client.PostAsJsonAsync("api/project/create", newProject);
        //Assert
        createdProject.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetProjectInfo_ReturnsValidData_WhenThereIdDataInTheDb()
    {
        //Act
        var response = await _client.GetAsync("api/project/projectInfo");
        var projectsInfo = await response.Content.ReadFromJsonAsync<LinkedList<ProjectTasksInfoDTO>>();
        //Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        projectsInfo.Should().NotBeNull();
        projectsInfo.Should().HaveCountGreaterThan(0);
    }


}
