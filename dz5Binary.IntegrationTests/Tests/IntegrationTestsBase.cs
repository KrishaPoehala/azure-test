using dz3Binary;
using dz3Binary.DAL.Context;
using dz5Binary.IntegrationTests.CustomFactories;
using dz5Binary.IntegrationTests.Helpers;
using dz6Binary;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace dz5Binary.IntegrationTests.Tests;
public class IntegrationTestsBase
{
    protected readonly HttpClient _client;
    protected readonly CustomWebApplicationFactory<Startup> _factory = new();
    public IntegrationTestsBase(CustomWebApplicationFactory<Startup> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }
}
