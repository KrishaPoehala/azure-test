namespace dz3Binary.DAL.DataLoaders;

public interface IDataLoader<T> 
{
    ICollection<T> Load();
}
