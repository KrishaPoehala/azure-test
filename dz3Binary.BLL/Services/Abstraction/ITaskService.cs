using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;

namespace dz3Binary.BLL.Services.Abstraction;

public interface ITaskService
{
    IEnumerable<IdNameOnlyTaskDTO> GetFinishedTasks(int userId);
    IEnumerable<TaskDTO> GetTasks(int userId);
    IDictionary<int, ProjectDTO> GetTasksCountByProject(int userId);
}
