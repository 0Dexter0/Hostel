namespace Hostel.Extensibility.Extensions;

public static class CollectionExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) =>
        collection is null || collection.GetEnumerator().MoveNext();
}