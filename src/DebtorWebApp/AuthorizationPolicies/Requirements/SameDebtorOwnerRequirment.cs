using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtorWebApp.AuthorizationPolicies.Requirements
{
    public class SameDebtorOwnerRequirment : IAuthorizationRequirement
    {
    }
}
