using dz3Binary.DAL.Entities;
using dz3Binary.DAL.Extentions;

namespace dz3Binary.DAL.DataLoaders;
public class UserLoader : BaseDataLoader<User>
{
    public override ICollection<User> Load() => _users
        .Join(_teams, u => u.TeamId, t => t.Id, (u, t) => { u.Team = t; return u; })
        .Join(_tasks, u => u.Id, t => t.PerformerId, (u, t) => { u.Tasks.Add(t); return u; })
        .Join(_projects, u => u.Id, p => p.AuthorId, (u, p) => { u.ProjectsCreated.Add(p); return u; })
        .Distinct()
        .ToLinkedList();
}
