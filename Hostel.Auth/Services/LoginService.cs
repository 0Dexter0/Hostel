using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hostel.Auth.Models;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hostel.Auth.Services;

internal class LoginService : ILoginService
{
    private readonly IAuthPersonalService _personalService;
    private readonly IConfiguration _configuration;

    public LoginService(IAuthPersonalService personalService, IConfiguration configuration)
    {
        _personalService = personalService;
        _configuration = configuration;
    }

    public string Login(PersonalLoginModel loginModel)
    {
        var personalToLogin =  _personalService.GetByPhoneNumber(loginModel.PhoneNumber);

        if (personalToLogin is null)
        {
            return null;
        }

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginModel.Password, personalToLogin.Password);

        return isPasswordValid ? CreateToken(personalToLogin) : null;
    }

    private string CreateToken(Personal personal)
    {
        List<Claim> claims = new() {
            new(ClaimTypes.MobilePhone, personal.PhoneNumber),
            new(ClaimTypes.Role, personal.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}