using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

    [HttpPut]
    [Route("put")]
    public async Task<ActionResult> PutUser(UserDTO userDTO)
    {
        await _userService.PutUser(userDTO);
        return Ok();
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

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<ActionResult<UserDTO>> DeleteUser(int id)
    {
        if (id < 0)
            return BadRequest();

        try
        {
            var userToDelete = await _userService.DeleteUser(id);
            return Ok(userToDelete);
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("getFirst")]
    public async Task<ActionResult<UserDTO>> GetFirst()
    {
        return Ok(await _userService.GetFirst());
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<UserDTO>> PostUser(NewUserDTO dto)
    {
        try
        {
            return Created("create",
                await _userService.CreateUser(dto));
        }
        catch
        {
            return BadRequest();
        }
    }
}
