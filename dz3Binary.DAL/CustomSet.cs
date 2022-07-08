using dz3Binary.DAL.DataLoaders;
using System.Collections;

namespace dz3Binary.DAL;

public class CustomSet<T> : ICollection<T>
{
    private readonly ICollection<T> _values;
    private readonly IDataLoader<T> _loader;
    public CustomSet(IDataLoader<T> loader)
    {
        _loader = loader;
        _values = _loader.Load();
    }
    public int Count => _values.Count;

    public bool IsReadOnly => _values.IsReadOnly;

    public void Add(T item) => _values.Add(item);


    public void Clear() => _values.Clear();

    public bool Contains(T item) => _values.Contains(item);

    public void CopyTo(T[] array, int arrayIndex) => _values.CopyTo(array, arrayIndex);

    public IEnumerator<T> GetEnumerator() => _values.GetEnumerator();

    public bool Remove(T item) => _values.Remove(item);

    IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();
}
