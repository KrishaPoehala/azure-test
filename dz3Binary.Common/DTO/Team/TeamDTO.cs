using dz3Binary.Common.DTO.User;

namespace dz3Binary.Common.DTO.Team;

public record TeamDTO
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<UserDTO> Members { get; set; } = new LinkedList<UserDTO>();
}
