using dz3Binary.Common.Profiles;
using dz3Binary.DAL.Context;
using dz3Binary.Extentions;
using Microsoft.EntityFrameworkCore;

namespace dz3Binary;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(option =>
option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
        services.AddDbContext<ProjectContext>(opt =>
        opt.UseSqlServer(_configuration.GetConnectionString("ProjectDatabase")));
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddCustomServices();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}
