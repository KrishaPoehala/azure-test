using dz3Binary.DAL.DataLoaders;
using dz3Binary.DAL.Entities;
namespace dz3Binary.DAL;

public class ProjectContext
{
    public CustomSet<Team> Teams { get; set; }
    public CustomSet<User> Users { get; set; }
    public CustomSet<Entities.Task> Tasks { get; set; }
    public CustomSet<Project> Projects { get; set; }

    public ProjectContext()
    {
        Teams = new(new TeamLoader());
        Tasks = new(new TaskLoader());
        Users = new(new UserLoader());
        Projects = new(new ProjectLoader());
    }
}
