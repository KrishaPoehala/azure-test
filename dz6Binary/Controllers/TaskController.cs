
using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<ActionResult<TaskDTO>> DeleteTask(int id)
    {
        try
        {
            return Ok(await _taskService.DeleteTask(id));
        }
        catch 
        {
            return NotFound();
        }
    }
    [HttpGet]
    [Route("getFirst")]
    public async Task<ActionResult<TaskDTO>> GetFirst()
    {
        return Ok(await _taskService.GetFirst());
    }

    [HttpPut]
    public async Task<ActionResult> FinishTask(int id)
    {
        try
        {
            await _taskService.FinishTask(id);
            return Ok();
        }
        catch (NullReferenceException)
        {
            return NotFound();
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskDTO>> GetUnfinishedTask(int userId)
    {
        return Ok(_taskService.GetUnfinishedTasks(userId));
    }

}
