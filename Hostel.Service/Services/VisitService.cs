using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

internal class VisitService : CrudServiceBase<Visit, VisitFilter>, IVisitService
{
    public VisitService(IVisitRepository repository)
        : base(repository)
    {
    }
}