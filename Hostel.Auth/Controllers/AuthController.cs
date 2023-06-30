using System.Security.Claims;
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
        var registerResult = _registrationService.Register(registerData);

        return registerResult.IsValid ? new OkObjectResult(registerResult) : new BadRequestObjectResult(registerResult);
    }

    [HttpPost("login")]
    public IActionResult Login(PersonalLoginModel loginData)
    {
        var tokenResult = _loginService.Login(loginData);

        if (!tokenResult.IsValid)
        {
            return new BadRequestObjectResult(tokenResult);
        }

        HttpContext.User.AddIdentity(new(new Claim[]{ new(ClaimTypes.MobilePhone, loginData.PhoneNumber) }));

        return new OkObjectResult(tokenResult);
    }
}