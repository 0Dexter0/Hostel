using Hostel.Auth.Models;

namespace Hostel.Auth.Services;

public interface ILoginService
{
    string Login(PersonalLoginModel loginModel);
}