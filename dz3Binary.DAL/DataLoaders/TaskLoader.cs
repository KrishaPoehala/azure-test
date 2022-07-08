using dz3Binary.DAL.Extentions;

namespace dz3Binary.DAL.DataLoaders;

public class TaskLoader : BaseDataLoader<Entities.Task>
{
    public override ICollection<Entities.Task> Load() => _tasks
            .Join(_users, t => t.PerformerId, u => u.Id, (t, u) => { t.Performer = u; return t; })
            .Distinct()
            .ToLinkedList();
}
