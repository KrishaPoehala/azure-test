using AutoMapper;
using dz3Binary.DAL.Context;
using dz3Binary.DAL.Entities;
using System.Threading.Tasks;
namespace dz3Binary.BLL.Services.Abstraction;

public abstract class ServiceBase<T> : IService<T> where T : BaseEntity
{
    protected readonly ProjectContext _context;
    protected readonly IMapper _mapper;
    protected ServiceBase(ProjectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<T> Get()
    {
        return _context.Set<T>();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().First(x => x.Id == id);
    }

    public async System.Threading.Tasks.Task IService<T>.Add(T entity)
    {
        if(entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public System.Threading.Tasks.Task IService<T>.Delete(T entity)
    {
        throw new NotImplementedException();
    }

    System.Threading.Tasks.Task IService<T>.Update(T entity)
    {
        throw new NotImplementedException();
    }
}
