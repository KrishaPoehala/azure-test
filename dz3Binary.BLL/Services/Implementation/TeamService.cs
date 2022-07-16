using AutoMapper;
using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Team;
using dz3Binary.Common.DTO.User;
using dz3Binary.DAL.Context;
using dz3Binary.DAL.Entities;
using dz3Binary.DAL.Extentions;
using Microsoft.EntityFrameworkCore;

namespace dz3Binary.BLL.Services.Abstraction;

public class TeamService : ServiceBase, ITeamService
{
    public TeamService(ProjectContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async System.Threading.Tasks.Task AddMember(UserDTO dto,int teamToAddId)
    {
        var user = _mapper.Map<User>(dto);
        var team = await _context.Teams
            .SingleOrDefaultAsync(x => x.Id == teamToAddId);

        if(user is null)
        {
            throw new NullReferenceException(nameof(user));
        }

        team.Members.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<TeamDTO> CreateTeam(NewTeamDTO newTeam)
    {
        if(newTeam is null)
        {
            throw new ArgumentNullException(nameof(newTeam));
        }    

        var teamToCreate = _mapper.Map<Team>(newTeam);
        _context.Add(teamToCreate);
        await _context.SaveChangesAsync();
        return _mapper.Map<TeamDTO>(teamToCreate);
    }

    public async Task<TeamDTO> Get(int id)
    {
        var team = await _context.Teams.SingleOrDefaultAsync(u => u.Id == id);
        if(team is null)
        {
            throw new NullReferenceException(nameof(team));
        }

        return _mapper.Map<TeamDTO>(team);
    }

    public IEnumerable<IdNameMembersOnlyTeamDTO> GetTeamInfo() => _context
            .Teams
            .Include(t => t.Members)
            .Where(t => t.Members.All(t => (DateTime.Today.Year - t.BirthDay.Year) > 10) || true)
            .AsEnumerable()
            .Select(t =>
            {
                t.Members = t.Members.OrderByDescending(m => m.RegisteredAt).ToLinkedList();
                return _mapper.Map<IdNameMembersOnlyTeamDTO>(t);
            });
}
