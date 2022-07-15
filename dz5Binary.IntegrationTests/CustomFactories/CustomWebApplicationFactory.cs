using dz3Binary.DAL.Context;
using dz5Binary.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Linq;

namespace dz5Binary.IntegrationTests.CustomFactories;

public class CustomWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services
            .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<ProjectContext>));
            services.Remove(descriptor);

            services.AddDbContext<ProjectContext>(options =>
            options.UseInMemoryDatabase("InMemoryDbForTesting"));
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetService<ProjectContext>();
            db.Database.EnsureCreated();
        });
    }
}

