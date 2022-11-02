using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using System.Linq;

namespace CMS.Policy1.Handlers
{
    public class ShouldBeAnAuthorizedHandler
    : AuthorizationHandler<ShouldBeAnAuthorizedRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ShouldBeAnAuthorizedRequirement requirement)
        {
            // check if Role claim exists - Else Return
            // (sort of Claim-based requirement)
            if (!context.User.HasClaim(x => x.Type == ClaimTypes.Email))
            {
                Console.WriteLine("claim found");
                return Task.CompletedTask;
            }
            // claim exists - retrieve the value

            var claim = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var mail = claim.Value;


            if (string.Equals(mail, "reader1001@me.com"))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
