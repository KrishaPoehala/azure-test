namespace dz3Binary.DAL.Entities;

public class User : BaseEntity
{
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime RegisteredAt { get; set; }
    public DateTime BirthDay { get; set; }

    public ICollection<Task> Tasks { get; set; } = new LinkedList<Task>();
    public ICollection<Project> ProjectsCreated { get; set; } = new LinkedList<Project>();
}
