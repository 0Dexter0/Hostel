using Hostel.Extensibility.Models;

namespace Hostel.Domain.Repositories;

public interface IAuthPersonalRepository
{
    Personal GetByPhoneNumber(string phoneNumber);

    bool Add(Personal model);
}