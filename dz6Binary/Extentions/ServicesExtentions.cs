using dz3Binary.BLL.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace dz3Binary.Extentions;

public static class ServicesExtentions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<ITeamService, TeamService>();
    }
}
