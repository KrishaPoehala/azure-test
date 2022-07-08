using AutoMapper;
using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Team;
using dz3Binary.DAL;
using dz3Binary.DAL.Extentions;

namespace dz3Binary.BLL.Services.Abstraction;

public class TeamService : ServiceBase, ITeamService
{
    public TeamService(ProjectContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public IEnumerable<IdNameMembersOnlyTeamDTO> GetTeam() => _context
            .Teams.Where(t => t.Members.All(t => (DateTime.Today.Year - t.BirthDay.Year) > 10))
            .Select(t =>
            {
                t.Members = t.Members.OrderByDescending(m => m.RegisteredAt).ToLinkedList();
                return _mapper.Map<IdNameMembersOnlyTeamDTO>(t);
            });
}
