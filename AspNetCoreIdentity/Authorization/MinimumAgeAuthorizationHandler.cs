using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Authorization
{
    public class MinimumAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            // TODO - check that the user is authenticated
            // TODO - get the question id from the request
            // TODO - get the user id from the name
            // identifier claim
            // TODO - get the question from the data
            // repository
            // TODO - if the question can't be found go to
            // the next piece of middleware
            // TODO - return failure if the user id in the
            // question from the data repository is
            // different to the user id in the request
            // TODO - return success if we manage to get here

            if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(x => x.Type == ClaimTypes.DateOfBirth).Value);
                var age = DateTime.Today.Year - dateOfBirth.Year;
                if (dateOfBirth > DateTime.Today.AddYears(-age))
                    age--;
                if (age >= requirement.MinimumAge)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            return Task.CompletedTask;
        }
    }
}
