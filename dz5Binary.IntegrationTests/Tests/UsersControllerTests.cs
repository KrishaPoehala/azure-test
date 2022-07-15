using dz3Binary;
using dz3Binary.Common.DTO.User;
using dz5Binary.IntegrationTests.CustomFactories;
using dz5Binary.IntegrationTests.Helpers;
using dz5Binary.IntegrationTests.Tests;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace dz5Binary.IntegrationTests;

public class UsersControllerTests :
    IntegrationTestsBase,
    IClassFixture<CustomWebApplicationFactory<Startup>>
{
    public UsersControllerTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async Task DeleteUser_DeletesAUser_WhenItExists()
    {
        // Arrange
        var userToDelete = await (await _client.GetAsync("api/user/getFirst"))
            .Content.ReadFromJsonAsync<UserDTO>();
        // Act
        var response = await _client.DeleteAsync("api/user/delete/" + userToDelete.Id);
        var deletedUser = await response.Content.ReadFromJsonAsync<DeletedUserDTO>();
        // Assert
        deletedUser.Id.Should().Be(userToDelete.Id);
    }

    [Fact]
    public async Task DeleteUser_NotFound_WhenItDoesNotExist()
    {
        // Act
        var response = await _client.DeleteAsync("api/user/delete/" + int.MaxValue);
        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

}
