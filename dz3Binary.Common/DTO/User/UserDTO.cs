using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.Common.DTO.Team;

namespace dz3Binary.Common.DTO.User;

public record UserDTO
{
    public int Id { get; set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public DateTime RegisteredAt { get; init; }
    public DateTime BirthDay { get; init; }

}
