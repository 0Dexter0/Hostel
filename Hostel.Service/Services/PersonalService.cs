using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

internal class SecurityPersonalService : CrudServiceBase<SecurityPersonal, PersonalFilter>, ISecurityPersonalService
{
    public SecurityPersonalService(ISecurityPersonalRepository repository)
        : base(repository)
    {
    }
}