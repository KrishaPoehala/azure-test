namespace dz3Binary.BLL.Services.Abstraction;

public interface IService<T>
{
    T GetById(int id);
    IEnumerable<T> Get();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
