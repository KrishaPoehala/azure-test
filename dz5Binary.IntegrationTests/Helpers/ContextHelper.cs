using dz3Binary.DAL.Context;
using dz3Binary.DAL.Extentions;
using System.Diagnostics;
using System.Linq;

namespace dz5Binary.IntegrationTests.Helpers;

public static class ContextHelper
{
    public static void InitializeDb(ProjectContext db)
    {
        var teams = ModelBuilderExtenstions.GenerateTeams(2);
        var users = ModelBuilderExtenstions.GenerateUsers(teams, 5);
        var projects = ModelBuilderExtenstions.GenerateProjects(users, teams, 10);
        var tasks = ModelBuilderExtenstions.GenerateTasks(projects, users, 30);
        db.Teams.AddRange(teams);
        db.Users.AddRange(users);
        db.Projects.AddRange(projects);
        db.Tasks.AddRange(tasks);
        db.SaveChanges();
    }

    public static void ReinitalizeDb(ProjectContext db)
    {
        db.Teams.RemoveRange(db.Teams);
        db.Users.RemoveRange(db.Users);
        db.Tasks.RemoveRange(db.Tasks);
        db.Projects.RemoveRange(db.Projects);
        db.SaveChanges();
        InitializeDb(db);
    }
}
