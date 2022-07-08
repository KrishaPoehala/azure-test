using dz3Binary.DAL.Entities;
using dz3Binary.DAL.Extentions;
using dz3Binary.DAL.Helpers;

namespace dz3Binary.DAL.DataLoaders;

public class TeamLoader : BaseDataLoader<Team>
{
    public override ICollection<Team> Load() => _teams
             .Join(_users, t => t.Id, u => u.TeamId, (t, u) => { t.Members.Add(u); return t; })
             .Distinct()
             .ToLinkedList();
}
