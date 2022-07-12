using AutoMapper;
using dz3Binary.DAL.Context;

namespace dz3Binary.BLL.Services.Abstraction;

public abstract class ServiceBase
{
    protected readonly ProjectContext _context;
    protected readonly IMapper _mapper;
    protected ServiceBase(ProjectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
