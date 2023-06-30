namespace Hostel.Auth.Resolvers;

public interface IRoleResolver
{
    bool HasAccess(string minimalRole, string currentRole);
}