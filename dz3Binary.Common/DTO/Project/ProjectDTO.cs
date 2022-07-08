using dz3Binary.Common.DTO.Task;
using dz3Binary.Common.DTO.Team;
using dz3Binary.Common.DTO.User;

namespace dz3Binary.Common.DTO.Project;

public record struct ProjectDTO
{
    public int AuthorId { get; init; }
    public UserDTO Author { get; init; }
    public int TeamId { get; init; }
    public TeamDTO Team { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public DateTime Deadline { get; init; }
    public DateTime CreatedAt { get; init; }
    public ICollection<TaskDTO> Tasks { get; init; } = new LinkedList<TaskDTO>();
}
