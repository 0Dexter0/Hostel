using Microsoft.AspNetCore.Mvc;

namespace Hostel.WebApi.Routes;

public class RestRouteAttribute : RouteAttribute
{
    public RestRouteAttribute(string template)
        : base($"rest/{template}")
    {
    }
}