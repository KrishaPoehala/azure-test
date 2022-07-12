
using System.ComponentModel.DataAnnotations;

namespace dz3Binary.DAL.Entities;

public class Project : BaseEntity
{
    public int AuthorId { get; set; }
    public virtual  User Author { get; set; }
    public int TeamId { get; set; }
    public virtual Team Team { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    [MaxLength(100)]
    public DateTime Deadline { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Entities.Task> Tasks { get; set; } = new LinkedList<Entities.Task>();
}
