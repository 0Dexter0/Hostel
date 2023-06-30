namespace Hostel.Extensibility.Extensions;

public static class ObjectExtensions
{
    public static List<T> AsList<T>(this T value) => new(new []{ value });
}