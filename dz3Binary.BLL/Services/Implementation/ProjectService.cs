using AutoMapper;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace dz3Binary.BLL.Services.Abstraction;

public class ProjectService : ServiceBase, IProjectService
{
    public ProjectService(ProjectContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public IEnumerable<ProjectTasksInfoDTO> GetProjectInfo() => _context
            .Projects
            .Include(p => p.Tasks)
            .Include(p => p.Team.Members)
            .AsEnumerable().Select(p => new ProjectTasksInfoDTO
            {
                Project = _mapper.Map<ProjectDTO>(p),
                LongestTask = _mapper.Map<TaskDTO>(p.Tasks.MaxBy(t => t.Description)),
                ShortestTask = _mapper.Map<TaskDTO>(p.Tasks.MinBy(t => t.RenamedName.Length)),
                UsersCount = (p.Description.Length > 20 || p.Tasks.Count > 3) ? p.Team.Members.Count : 0,
            });

}
