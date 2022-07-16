using dz3Binary.Common.DTO.Team;
using dz3Binary.Common.DTO.User;

namespace dz3Binary.BLL.Services.Abstraction
{
    public interface ITeamService
    {
        IEnumerable<IdNameMembersOnlyTeamDTO> GetTeamInfo();
        Task AddMember(UserDTO dto,int teamToAdd);
        Task<TeamDTO> CreateTeam(NewTeamDTO newTeam);
        Task<TeamDTO> Get(int id);
    }
}