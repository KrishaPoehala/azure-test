using AutoMapper;
using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.Common.DTO.User;
using dz3Binary.DAL;
using dz3Binary.DAL.Extentions;
using Microsoft.EntityFrameworkCore;

namespace dz3Binary.BLL.Services.Abstraction;
public class UserService : ServiceBase, IUserService
{
    public UserService(ProjectContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public IEnumerable<UserDTO> GetSortedUsers() => _context
            .Users.OrderBy(u => u.FirstName)
            .AsEnumerable()
            .Select(u =>
            {
                u.Tasks = u.Tasks.OrderBy(t => t.Name).ToLinkedList();
                return _mapper.Map<UserDTO>(u);
            });

    public IEnumerable<UserTasksInfoDTO> GetTasksInfo(int userId) => _context
            .Users.Include(u => u.ProjectsCreated).AsEnumerable()
            .Select(u => new UserTasksInfoDTO
            {
                User = _mapper.Map<UserDTO>(u),
                LastProject = _mapper.Map<ProjectDTO>(u.ProjectsCreated.MaxBy(p => p.CreatedAt)),
                TasksCount = u.ProjectsCreated.MaxBy(p => p.CreatedAt).Tasks.Count,
                CancelledOrInProgressTasksCount = u.Tasks.Count(t => t.State == 1 || t.State == 3),
                LongestTask = _mapper.Map<TaskDTO>(u.Tasks.MaxBy(t => t?.FinishedAt - t.CreatedAt)),
            });


}
