using Hostel.Domain.Repositories;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

internal class AuthPersonalService : IAuthPersonalService
{
    private readonly IAuthPersonalRepository _authPersonalRepository;

    public AuthPersonalService(IAuthPersonalRepository authPersonalRepository)
    {
        _authPersonalRepository = authPersonalRepository;
    }

    public Personal GetByPhoneNumber(string phoneNumber) => _authPersonalRepository.GetByPhoneNumber(phoneNumber);

    public bool Add(Personal model) => _authPersonalRepository.Add(model);
}