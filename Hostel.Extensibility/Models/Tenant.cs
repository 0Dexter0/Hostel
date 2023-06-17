namespace Hostel.Extensibility.Models;

public record Tenant : SecurityTenant
{
    public string Password { get; init; }
}
