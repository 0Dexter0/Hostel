using Hostel.Extensibility.Models;

namespace Hostel.Auth.Services;

public interface IRegistrationService
{
    bool Register(Personal registerData);
}