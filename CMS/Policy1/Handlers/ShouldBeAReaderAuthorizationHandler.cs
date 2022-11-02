using CMS.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CMS.Policy1
{
    public class ShouldBeAReaderAuthorizationHandler
    : AuthorizationHandler<ShouldBeAReaderRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ShouldBeAReaderRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == ClaimTypes.Email))
                return Task.CompletedTask;

            var claim = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var emailAddress = claim.Value;

            if (UserData.Readers.Any(x => x.EmailAddress == emailAddress))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}