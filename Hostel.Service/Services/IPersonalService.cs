using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

public interface ISecurityPersonalService : ICrudServiceBase<SecurityPersonal, PersonalFilter>
{
}