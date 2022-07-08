using dz3Binary.Common.DTO.User;
namespace dz3Binary.Common.DTO.Team;
public record IdNameMembersOnlyTeamDTO
{
    public int Id { get; init; }
    public string Name { get; init; }
    public ICollection<UserDTO> Users { get; init; }
}
