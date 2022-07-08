using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Team;
using Microsoft.AspNetCore.Mvc;

namespace dz3Binary.Controllers;

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


}
