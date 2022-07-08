namespace dz3Binary.DAL.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<User> Members { get; set; } = new LinkedList<User>();
}
