using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

public interface IAuthPersonalService
{
    Personal GetByPhoneNumber(string phoneNumber);

    bool Add(Personal model);
}