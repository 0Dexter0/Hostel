using Hostel.Extensibility.Models;

namespace Hostel.Service.Providers;

public interface ICurrentUserProvider
{
    SecurityPersonal GetCurrentUser();
}