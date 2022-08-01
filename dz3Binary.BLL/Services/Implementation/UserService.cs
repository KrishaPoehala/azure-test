using AutoMapper;
using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.Common.DTO.User;
using dz3Binary.DAL.Context;
using dz3Binary.DAL.Entities;
using dz3Binary.DAL.Extentions;
using Microsoft.EntityFrameworkCore;

namespace dz3Binary.BLL.Services.Abstraction;
public class UserService : ServiceBase, IUserService
{
    public UserService(ProjectContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async System.Threading.Tasks.Task PutUser(UserDTO dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == dto.Id);
        user.Email = dto.Email;
        user.BirthDay = dto.BirthDay;
        user.LastName = dto.LastName;
        user.FirstName = dto.FirstName;
        await _context.SaveChangesAsync();
    }

    public async Task<UserDTO> CreateUser(NewUserDTO dto)
    {
        if(dto is null)
        {
            throw new NullReferenceException(nameof(dto));
        }

        var userToCreate = _mapper.Map<User>(dto);
        _context.Add(userToCreate);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDTO>(userToCreate);
    }

    public async Task<DeletedUserDTO> DeleteUser(int userId)
    {
        var userToDelete = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        if(userToDelete is null)
        {
            throw new NullReferenceException(nameof(userToDelete));
        }

        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();
        return _mapper.Map<DeletedUserDTO>(userToDelete);  
    }

    public async Task<UserDTO> GetFirst()
    {
        return _mapper.Map<UserDTO>(await _context.Users.FirstOrDefaultAsync());
    }

    public IEnumerable<UserDTO> GetSortedUsers() => _context
            .Users.OrderBy(u => u.FirstName)
            .AsEnumerable()
            .Select(u =>
            {
                u.Tasks = u.Tasks.OrderBy(t => t.RenamedName).ToLinkedList();
                return _mapper.Map<UserDTO>(u);
            });

    public IEnumerable<UserTasksInfoDTO> GetTasksInfo(int userId) => _context
            .Users
            .Where(u => u.Id == userId)
            .Include(u => u.Tasks)
            .Include(u => u.ProjectsCreated)
                .ThenInclude(p => p.Tasks)
            .AsEnumerable()
            .Select(u => new UserTasksInfoDTO
            {
                User = _mapper.Map<UserDTO>(u),
                LastProject = _mapper.Map<ProjectDTO>(u.ProjectsCreated.MaxBy(p => p.CreatedAt)),
                TasksCount = u.ProjectsCreated.MaxBy(p => p.CreatedAt).Tasks.Count,
                CancelledOrInProgressTasksCount = u.Tasks.Count(t => t.State == 1 || t.State == 3),
                LongestTask = _mapper.Map<TaskDTO>(u.Tasks.MaxBy(t => t?.FinishedAt - t.CreatedAt)),
            });
}
