using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Team;
using Microsoft.AspNetCore.Mvc;

namespace dz3Binary.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpGet]
    [Route("teamInfo")]
    public ActionResult<IEnumerable<IdNameMembersOnlyTeamDTO>> GetTeamInfo()
    {
        return Ok(_teamService.GetTeamInfo());
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<TeamDTO>> CreateTeam(NewTeamDTO dto)
    {
        try
        {
            return Ok(await _teamService.CreateTeam(dto));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("get/{id}")]
    public async Task<ActionResult<TeamDTO>> GetById(int id)
    {
        try
        {
            var team = await _teamService.Get(id);
            return Ok(team);

        }
        catch
        {
            return NotFound();
        }
    }


}
