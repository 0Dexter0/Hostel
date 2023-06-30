using Hostel.Extensibility.Extensions;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;

namespace Hostel.Auth.Services;

internal class RegistrationService : IRegistrationService
{
    private readonly IAuthPersonalService _personalService;

    public RegistrationService(IAuthPersonalService personalService)
    {
        _personalService = personalService;
    }

    public bool Register(Personal registerData)
    {
        var existingPersonal = _personalService.GetByPhoneNumber(registerData.PhoneNumber);

        if (existingPersonal is not null)
        {
            return false;
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerData.Password);

        return _personalService.Add(registerData with { Password = passwordHash });
    }
}