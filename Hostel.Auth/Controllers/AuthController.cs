using Hostel.Auth.Models;
using Hostel.Auth.Services;
using Hostel.Extensibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.Auth.Controllers;

public class AuthController : ControllerBase
{
    private readonly IRegistrationService _registrationService;
    private readonly ILoginService _loginService;

    public AuthController(IRegistrationService registrationService, ILoginService loginService)
    {
        _registrationService = registrationService;
        _loginService = loginService;
    }

    [HttpPost("register")]
    public IActionResult Register(Personal registerData)
    {
        bool isRegistered = _registrationService.Register(registerData);

        return isRegistered ? new OkResult() : new BadRequestResult();
    }

    [HttpPost("login")]
    public IActionResult Login(PersonalLoginModel loginData)
    {
        string token = _loginService.Login(loginData);

        if (token is null)
        {
            return new BadRequestResult();
        }

        // HttpContext.User.AddIdentity(new(new Claim[]{ new(ClaimTypes.MobilePhone, loginData.PhoneNumber) }));

        return new OkObjectResult(token);
    }
}