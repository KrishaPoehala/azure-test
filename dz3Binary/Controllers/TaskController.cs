
using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using Microsoft.AspNetCore.Mvc;

namespace dz3Binary.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    [Route("tasksCountByProject/{userId}")]
    public ActionResult<IDictionary<int, ProjectDTO>> GetTasksCountByProject(int userId)
    {
        return Ok(_taskService.GetTasksCountByProject(userId));
    }

    [HttpGet]
    [Route("tasks/{userId}")]
    public ActionResult<IEnumerable<TaskDTO>> GetTasks(int userId)
    {
        return Ok(_taskService.GetTasks(userId));
    }

    [HttpGet]
    [Route("finishedTasks/{userId}")]
    public ActionResult<IEnumerable<IdNameOnlyTaskDTO>> GetFinishedTasks(int userId)
    {
        return Ok(_taskService.GetFinishedTasks(userId));
    }
}
