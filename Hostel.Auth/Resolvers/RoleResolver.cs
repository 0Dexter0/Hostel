namespace Hostel.Auth.Resolvers;

internal class RoleResolver : IRoleResolver
{
    public bool HasAccess(string minimalRole, string currentRole)
    {
        if (minimalRole == currentRole)
        {
            return true;
        }

        if (minimalRole is Roles.Watchman)
        {
            return true;
        }

        if (minimalRole is Roles.Commandant && currentRole is Roles.Commandant or Roles.Admin)
        {
            return true;
        }

        return false;
    }
}