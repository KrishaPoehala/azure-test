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
            .WithMany(t => t.Members)
            .HasForeignKey(u => u.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ProjectsCreated)
            .WithOne(p => p.Author)
            .HasForeignKey(u => u.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Tasks)
            .WithOne(t => t.Performer)
            .HasForeignKey(t => t.PerformerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Entities.Task>()
            .HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Entities.Task>()
            .HasOne(t => t.Performer)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
            
    }
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var teams = GenerateTeams(2);
        var users = GenerateUsers(teams,10);
        var projects = GenerateProjects(users, teams,20);
        var tasks = GenerateTasks(projects, users,100);
        modelBuilder.Entity<Team>().HasData(teams);
        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Project>().HasData(projects);
        modelBuilder.Entity<Entities.Task>().HasData(tasks);
    }

    public static IList<Team> GenerateTeams(int count)
    {
        int index = 1;
        var teamFaker = new Faker<Team>()
            .RuleFor(x => x.Id, f => index++)
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.CreatedAt, f => f.Date.Past());

        return teamFaker.Generate(count);//2
    }

    public static IList<User> GenerateUsers(IList<Team> teams,int count)
    {
        var index = 12;
        var taskFaker = new Faker<User>()
            .RuleFor(x => x.Id, f => index++)
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.BirthDay, f => f.Date.Past())
            .RuleFor(x => x.TeamId, f => f.PickRandom(teams).Id);

        return taskFaker.Generate(count);//30
    }

    public static IList<Project> GenerateProjects(IList<User> users, IList<Team> teams,int count)
    {
        var index = 12;
        var projectFaker = new Faker<Project>()
            .RuleFor(x => x.Id, f => index++)
            .RuleFor(x => x.Name, f => f.Name.JobArea())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence(7))
            .RuleFor(x => x.CreatedAt, f => f.Date.Past())
            .RuleFor(x => x.Deadline, f => f.Date.Future())
            .RuleFor(x => x.TeamId, f => f.PickRandom(teams).Id)
            .RuleFor(x => x.AuthorId, f => f.PickRandom(users).Id)
            .RuleFor(x => x.TeamId, f=> f.PickRandom(teams).Id);

        return projectFaker.Generate(count);//20
    }

    public static IList<Entities.Task> GenerateTasks(IList<Project> projects, IList<User> users,int count)
    {
        var index = 12;

        var taskFaker = new Faker<Entities.Task>()
                    .RuleFor(x => x.Id, f => index++)
                    .RuleFor(x => x.RenamedName, f => f.Name.FirstName())
                    .RuleFor(x => x.Description, f => f.Lorem.Sentence(5))
                    .RuleFor(x => x.State, f => f.Random.Int(0, 3))
                    .RuleFor(x => x.CreatedAt, f => f.Date.Past())
                    .RuleFor(x => x.FinishedAt, f => f.Date.Past().OrNull(f, 0.3f))
                    .RuleFor(x => x.ProjectId, f => f.PickRandom(projects).Id)
                    .RuleFor(x => x.PerformerId, f => f.PickRandom(users).Id);

        return taskFaker.Generate(count);//100
    }
}
