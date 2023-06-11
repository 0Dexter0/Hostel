using Hostel.Extensibility.Filters;

namespace Hostel.Domain.Repositories;

public interface IHostelRepository : ICrudRepositoryBase<Extensibility.Models.Hostel, HostelFilter>
{
}