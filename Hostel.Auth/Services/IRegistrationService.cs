using Hostel.Domain.Models.Response;
using Hostel.Extensibility.Models;

namespace Hostel.Auth.Services;

public interface IRegistrationService
{
    OperationResponse Register(Personal registerData);
}