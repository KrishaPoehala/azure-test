using AutoMapper;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.DAL.Context;
using dz3Binary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace dz3Binary.BLL.Services.Abstraction;

public class ProjectService : ServiceBase, IProjectService
{
    public ProjectService(ProjectContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async System.Threading.Tasks.Task<ProjectDTO> CreateProject(NewProjectDTO projectDTO)
    {
        if(projectDTO is null)
        {
            throw new ArgumentNullException(nameof(projectDTO));
        }

        var project = _mapper.Map<Project>(projectDTO);
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProjectDTO>(project);
    }

    public async Task<ProjectDTO> GetProject(int id)
    {
        var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);
        if(project is null)
        {
            throw new ArgumentException(nameof(id));
        }

        return _mapper.Map<ProjectDTO>(project);
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
