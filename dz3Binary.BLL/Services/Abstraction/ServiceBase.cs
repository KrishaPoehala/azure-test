using AutoMapper;
using dz3Binary.DAL.Context;
using dz3Binary.DAL.Entities;
using System.Threading.Tasks;
namespace dz3Binary.BLL.Services.Abstraction;

public abstract class ServiceBase
{
    protected readonly ProjectContext _context;
    protected readonly IMapper _mapper;
    //for integrating testing
    protected ServiceBase(ProjectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
