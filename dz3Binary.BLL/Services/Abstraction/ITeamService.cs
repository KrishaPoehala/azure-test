using dz3Binary.Common.DTO.Team;

namespace dz3Binary.BLL.Services.Abstraction
{
    public interface ITeamService
    {
        IEnumerable<IdNameMembersOnlyTeamDTO> GetTeamInfo();

    }
}