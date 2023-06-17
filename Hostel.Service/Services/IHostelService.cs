using Hostel.Extensibility.Filters;

namespace Hostel.Service.Services;

public interface IHostelService : ICrudServiceBase<Extensibility.Models.Hostel, HostelFilter>
{
}