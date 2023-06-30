using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

public interface ICurrentUserProvider
{
    SecurityPersonal GetCurrentUser();
}