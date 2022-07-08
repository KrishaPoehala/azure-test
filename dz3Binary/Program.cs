using dz3Binary.Common.Profiles;
using dz3Binary.DAL;
using dz3Binary.Extentions;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddSingleton<ProjectContext>();
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
