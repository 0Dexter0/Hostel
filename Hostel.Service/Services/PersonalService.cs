using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

internal class PersonalService : CrudServiceBase<SecurityPersonal, PersonalFilter>, IPersonalService
{
    public PersonalService(IPersonalRepository repository)
        : base(repository)
    {
    }
}