// using System.Security.Claims;
// using Hostel.Auth.Resolvers;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;
//
// namespace Hostel.Auth.Attributes;
//
// [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
// public class RoleAuthorizeAttribute : IActionFilter
// {
//     private readonly IRoleResolver _roleResolver;
//
//     public RoleAuthorizeAttribute()
//     {
//         _roleResolver = new RoleResolver();
//     }
//
//     public void OnActionExecuting(ActionExecutingContext context)
//     {
//         var role = context.HttpContext.User.FindFirst(x => x.Type is ClaimTypes.Role);
//
//         if (role is null || !_roleResolver.HasAccess(Roles, role.Value))
//         {
//             context.Result = new ForbidResult();
//         }
//     }
//
//     public void OnActionExecuted(ActionExecutedContext context)
//     {
//     }
// }