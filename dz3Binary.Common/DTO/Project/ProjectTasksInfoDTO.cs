using dz3Binary.Common.DTO.Task;
using dz3Binary.Common.DTO.User;

namespace dz3Binary.Common.DTO.Project;

public record ProjectTasksInfoDTO
{
    public ProjectDTO Project { get; init; }
    public TaskDTO LongestTask { get; init; }
    public TaskDTO ShortestTask { get; init; }
    public int UsersCount { get; init; }
}
