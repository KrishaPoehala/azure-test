using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;

namespace dz3Binary.Common.DTO.User;

public record UserTasksInfoDTO
{
    public UserDTO User { get; init; }
    public ProjectDTO LastProject { get; init; }
    public int TasksCount { get; init; }
    public int CancelledOrInProgressTasksCount { get; init; }
    public TaskDTO LongestTask { get; init; }
}
