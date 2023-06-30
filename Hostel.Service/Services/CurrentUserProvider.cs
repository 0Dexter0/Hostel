using System.Security.Claims;
using Hostel.Extensibility.Extensions;
using Hostel.Extensibility.Models;
using Microsoft.AspNetCore.Http;

namespace Hostel.Service.Services;

internal class CurrentUserProvider : ICurrentUserProvider
{
    private readonly HttpContext _context;
    private readonly ISecurityPersonalService _personalService;
    private SecurityPersonal _currentUser;

    public CurrentUserProvider(HttpContext context, ISecurityPersonalService personalService)
    {
        _context = context;
        _personalService = personalService;
    }

    public SecurityPersonal GetCurrentUser()
    {
        if (_currentUser is not null)
        {
            return _currentUser;
        }

        var phoneNumber = _context.User.FindFirst(x => x.Type is ClaimTypes.MobilePhone);
        ArgumentNullException.ThrowIfNull(phoneNumber);

        var currentUser = _personalService.GetAll(
            new() { PhoneNumber = phoneNumber.Value.AsList() }).Result.FirstOrDefault();

        _currentUser = currentUser ?? throw new InvalidDataException($"User with {phoneNumber.Value} phone number doesn't exist.");

        return _currentUser;
    }
}