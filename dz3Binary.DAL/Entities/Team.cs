using System.ComponentModel.DataAnnotations;

namespace dz3Binary.DAL.Entities;

public class Team : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Project> Projects { get; set; } = new LinkedList<Project>();
    public virtual ICollection<User> Members { get; set; } = new LinkedList<User>();
}
