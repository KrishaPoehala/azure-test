using dz3Binary.DAL.Entities;
using dz3Binary.DAL.Extentions;

namespace dz3Binary.DAL.DataLoaders;

public class ProjectLoader : BaseDataLoader<Project>
{
    public override ICollection<Project> Load() => _projects
        .Join(_tasks, p => p.Id, t => t.ProjectId, (p, t) => { p.Tasks.Add(t); return p; })
        .Join(_teams, p => p.TeamId, t => t.Id, (p, t) => { p.Team = t; return p; })
        .Join(_users, p => p.AuthorId, t => t.Id, (p, u) => { p.Author = u; return p; })
        .Distinct()
        .ToLinkedList();
}
