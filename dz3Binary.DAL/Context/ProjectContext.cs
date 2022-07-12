using Bogus;
using dz3Binary.DAL.Entities;
using dz3Binary.DAL.Extentions;
using Microsoft.EntityFrameworkCore;

namespace dz3Binary.DAL.Context;

public class ProjectContext : DbContext
{
    public DbSet<Team> Teams { get; private set; }
    public DbSet<User> Users { get; private set; }
    public DbSet<Entities.Task> Tasks { get; private set; }
    public DbSet<Project> Projects { get; private set; }

    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();
        modelBuilder.Seed();
    }
}
