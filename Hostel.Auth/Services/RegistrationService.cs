using Hostel.Domain.Models.Response;
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

    public OperationResponse Register(Personal registerData)
    {
        var existingPersonal = _personalService.GetByPhoneNumber(registerData.PhoneNumber);

        if (existingPersonal is not null)
        {
            return new(MessageLevel.Error, "User with this phone number already exists.");
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerData.Password);

        var result = _personalService.Add(registerData with { Password = passwordHash });

        if (result)
        {
            return new();
        }

        return new(MessageLevel.Error, "Can't register user with current data.");
    }
}