using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;

namespace Hostel.Service.Services;

public class HostelService : CrudServiceBase<Extensibility.Models.Hostel, HostelFilter>, IHostelService
{
    public HostelService(IHostelRepository repository)
        : base(repository)
    {
    }
}