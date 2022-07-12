using System.ComponentModel.DataAnnotations;

namespace dz3Binary.DAL.Entities;

public class User : BaseEntity
{
    public int? TeamId { get; set; }
    public virtual Team? Team { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    [Required]
    public DateTime RegisteredAt { get; set; }
    public DateTime BirthDay { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new LinkedList<Task>();
    public virtual ICollection<Project> ProjectsCreated { get; set; } = new LinkedList<Project>();
}
