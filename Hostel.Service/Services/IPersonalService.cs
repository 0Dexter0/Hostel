using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

public interface IPersonalService : ICrudServiceBase<SecurityPersonal, PersonalFilter>
{
}