using DebtorWebApp.Areas.Identity.Roles;
using DebtorWebApp.AuthorizationPolicies.Requirements;
using DebtorWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtorWebApp.AuthorizationPolicies
{
    public class DebtorAuthorizationHandler : AuthorizationHandler<SameDebtorOwnerRequirment, Debtor>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public DebtorAuthorizationHandler(UserManager<IdentityUser> userManager) => _userManager = userManager;

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameDebtorOwnerRequirment requirement, Debtor resource)
        {
            string userID = _userManager.GetUserId(context.User);
            if (userID != null && resource != null)
            {
                if ((userID == resource.OwnerID) && context.User.IsInRole(ApplicationRoles.Administrator.ToString()))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
