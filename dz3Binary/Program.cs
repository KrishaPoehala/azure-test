using dz3Binary.Common.Profiles;
using dz3Binary.DAL.Context;
using dz3Binary.Extentions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(option =>  
option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<ProjectContext>(opt => 
opt.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDatabase")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddCustomServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
