using System.ComponentModel.DataAnnotations;

namespace dz3Binary.DAL.Entities;

public class Task : BaseEntity
{
    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }
    public int PerformerId { get; set; }
    public virtual User Performer { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
    public int State { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
}
