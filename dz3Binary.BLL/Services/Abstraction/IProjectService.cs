using dz3Binary.Common.DTO.Project;

namespace dz3Binary.BLL.Services.Abstraction;

public interface IProjectService
{
    IEnumerable<ProjectTasksInfoDTO> GetProjectInfo();
}
