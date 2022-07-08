using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Project;
using Microsoft.AspNetCore.Mvc;

namespace dz3Binary.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    [Route("projectInfo")]
    public ActionResult<IEnumerable<ProjectTasksInfoDTO>> GetProjectInfo()
    {
        return Ok(_projectService.GetProjectInfo());
    }
}
