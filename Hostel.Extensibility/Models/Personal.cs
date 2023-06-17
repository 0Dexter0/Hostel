namespace Hostel.Extensibility.Models;

public record Personal : SecurityPersonal
{
    public string Password { get; init; }
}
