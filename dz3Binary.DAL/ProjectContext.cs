using Bogus;
using dz3Binary.DAL.DataLoaders;
using dz3Binary.DAL.Entities;
using dz3Binary.DAL.Extentions;
using Microsoft.EntityFrameworkCore;

namespace dz3Binary.DAL;

public class ProjectContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Entities.Task> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }

    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();
        modelBuilder.Seed();
    }
}
