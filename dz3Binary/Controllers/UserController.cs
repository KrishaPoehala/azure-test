using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace dz3Binary.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("sortedUsers")]
    public ActionResult<IEnumerable<UserDTO>> GetSortedUsers()
    {
        return Ok(_userService.GetSortedUsers());
    }

    [HttpGet]
    [Route("tasksInfo/{userId}")]
    public ActionResult<IEnumerable<UserTasksInfoDTO>> GetTasksInfo(int userId)
    {
        return Ok(_userService.GetTasksInfo(userId));
    }
}
