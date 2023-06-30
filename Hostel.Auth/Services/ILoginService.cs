using Hostel.Auth.Models;
using Hostel.Domain.Models.Response;

namespace Hostel.Auth.Services;

public interface ILoginService
{
    OperationResponse<string> Login(PersonalLoginModel loginModel);
}