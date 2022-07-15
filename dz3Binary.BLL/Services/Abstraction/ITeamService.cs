using dz3Binary.Common.DTO.Team;

namespace dz3Binary.BLL.Services.Abstraction
{
    public interface ITeamService
    {
        IEnumerable<IdNameMembersOnlyTeamDTO> GetTeamInfo();
        Task<TeamDTO> CreateTeam(NewTeamDTO newTeam);
        Task<TeamDTO> Get(int id);
    }
}