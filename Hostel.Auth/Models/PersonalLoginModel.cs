namespace Hostel.Auth.Models;

public record PersonalLoginModel
{
    public string PhoneNumber { get; init; }

    public string Password { get; init; }
}