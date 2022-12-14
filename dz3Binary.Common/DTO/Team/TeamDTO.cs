using dz3Binary.Common.DTO.User;

namespace dz3Binary.Common.DTO.Team;

public record TeamDTO
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateTime CreatedAt { get; init; }
    public ICollection<UserDTO> Members { get; init; } = new LinkedList<UserDTO>();
}
