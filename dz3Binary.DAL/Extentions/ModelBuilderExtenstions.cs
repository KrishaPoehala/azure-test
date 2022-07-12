using Bogus;
using dz3Binary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace dz3Binary.DAL.Extentions;

public static class ModelBuilderExtenstions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>()
            .HasMany(t => t.Members)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Team>()
            .HasMany(t => t.Projects)
            .WithOne(p => p.Team)
            .HasForeignKey(p => p.TeamId);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Author)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(p => p.AuthorId);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Team)
            .WithMany(t => t.Projects)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Team)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(u => u.TeamId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ProjectsCreated)
            .WithOne(p => p.Author)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(u => u.AuthorId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Tasks)
            .WithOne(t => t.Performer)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(t => t.PerformerId);

        modelBuilder.Entity<Entities.Task>()
            .HasOne(t => t.Project)
            .WithMany()
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Entities.Task>()
            .HasOne(t => t.Performer)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
            
    }
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var teams = GenerateTeams();
        var users = GenerateUsers(teams);
        var projects = GenerateProjects(users, teams);
        var tasks = GenerateTasks(projects, users);
        modelBuilder.Entity<Team>().HasData(teams);
        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Project>().HasData(projects);
        modelBuilder.Entity<Entities.Task>().HasData(tasks);
    }

    private static IList<Team> GenerateTeams()
    {
        int index = 1;
        var teamFaker = new Faker<Team>()
            .RuleFor(x => x.Id, f => index++)
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.CreatedAt, f => f.Date.Past());

        return teamFaker.Generate(2);
    }

    private static IList<User> GenerateUsers(IList<Team> teams)
    {
        var index = 1;
        var taskFaker = new Faker<User>()
            .RuleFor(x => x.Id, f => index++)
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.BirthDay, f => f.Date.Past())
            .RuleFor(x => x.TeamId, f => f.PickRandom(teams).Id);

        return taskFaker.Generate(5);
    }

    private static IList<Project> GenerateProjects(IList<User> users, IList<Team> teams)
    {
        var index = 1;
        var projectFaker = new Faker<Project>()
            .RuleFor(x => x.Id, f => index++)
            .RuleFor(x => x.Name, f => f.Name.JobArea())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence(7))
            .RuleFor(x => x.CreatedAt, f => f.Date.Past())
            .RuleFor(x => x.Deadline, f => f.Date.Future())
            .RuleFor(x => x.TeamId, f => f.PickRandom(teams).Id)
            .RuleFor(x => x.AuthorId, f => f.PickRandom(users).Id)
            .RuleFor(x => x.TeamId, f=> f.PickRandom(teams).Id);

        return projectFaker.Generate(3);
    }

    private static IList<Entities.Task> GenerateTasks(IList<Project> projects, IList<User> users)
    {
        var index = 1;

        var taskFaker = new Faker<Entities.Task>()
                    .RuleFor(x => x.Id, f => index++)
                    .RuleFor(x => x.Name, f => f.Name.FirstName())
                    .RuleFor(x => x.Description, f => f.Lorem.Sentence(5))
                    .RuleFor(x => x.State, f => f.Random.Int(0, 3))
                    .RuleFor(x => x.CreatedAt, f => f.Date.Past())
                    .RuleFor(x => x.FinishedAt, f => f.Date.Past().OrNull(f, 0.3f))
                    .RuleFor(x => x.ProjectId, f => f.PickRandom(projects).Id)
                    .RuleFor(x => x.PerformerId, f => f.PickRandom(users).Id);

        return taskFaker.Generate(10);
    }
}
