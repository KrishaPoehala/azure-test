using AutoMapper;
using dz3Binary.BLL.Services.Abstraction;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.DAL;

namespace dz3Binary.BLL.Services.Abstraction;

public class TaskService : ServiceBase, ITaskService
{
    public TaskService(ProjectContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public IDictionary<int, ProjectDTO> GetTasksCountByProject(int userId) => _context
            .Projects.Where(p => p.AuthorId == userId)
            .Select(p => _mapper.Map<ProjectDTO>(p))
            .ToDictionary(p => p.Tasks.Count);

    public IEnumerable<TaskDTO> GetTasks(int userId) => _context
            .Tasks.Where(t => t.PerformerId == userId && t.Name.Length < 45)
            .Select(t => _mapper.Map<TaskDTO>(t));

    public IEnumerable<IdNameOnlyTaskDTO> GetFinishedTasks(int userId) => _context
            .Tasks.Where(t => t.FinishedAt?.Year == 2022 && t.PerformerId == userId)
            .Select(t => _mapper.Map<IdNameOnlyTaskDTO>(t));




}
