using dz3Binary;
using dz3Binary.Common.DTO.Team;
using dz5Binary.IntegrationTests.CustomFactories;
using FluentAssertions;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace dz5Binary.IntegrationTests.Tests;

public class TeamsControllerTests :
    IntegrationTestsBase,
    IClassFixture<CustomWebApplicationFactory<Startup>>
{
    public TeamsControllerTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async Task CreateCommand_CreateACommand_WhenDataIsValid()
    {
        //Arrange
        var teamToCreate = new NewTeamDTO() { Name = "fdfdfd" };
        //Act
        var createdTeam = await (await _client.PostAsJsonAsync("api/team/create", teamToCreate))
            .Content.ReadFromJsonAsync<TeamDTO>();
            
        //Assert
        var response = await _client.GetAsync($"api/team/get/{createdTeam.Id}");
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        var teamFromDb = await response.Content.ReadFromJsonAsync<TeamDTO>();
        teamFromDb.Id.Should().Be(createdTeam.Id);
    }

    [Fact]
    public async Task CreateCommand_BadRequest_WhenNewDtoIdNull()
    {
        //Arrange
        NewTeamDTO teamToCreate = null;
        //Act
        var createdTeam = (await _client.PostAsJsonAsync("api/team/create", teamToCreate));
        //Assert
        createdTeam.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }
}
