using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Domain.Repositories;

public interface ISecurityPersonalRepository : ICrudRepositoryBase<SecurityPersonal, PersonalFilter>
{
}