using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.Common.DTO.Team;

namespace dz3Binary.Common.DTO.User;

public record UserDTO
{
    public int? TeamId { get; init; }
    public TeamDTO? Team { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public DateTime RegisteredAt { get; init; }
    public DateTime BirthDay { get; init; }

    public ICollection<TaskDTO> Tasks { get; init; } = new LinkedList<TaskDTO>();
    public ICollection<ProjectDTO> ProjectsCreated { get; init; } = new LinkedList<ProjectDTO>();
}
