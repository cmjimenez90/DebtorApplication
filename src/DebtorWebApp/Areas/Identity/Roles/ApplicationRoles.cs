using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtorWebApp.Areas.Identity.Roles
{
    public static class ApplicationRoles
    {
        public static Dictionary<RolesTypes, string> Roles = new Dictionary<RolesTypes, string>()
        {
            {RolesTypes.Administrator,"Administrator" },
            { RolesTypes.User,"User"}
        };
    }

    public enum RolesTypes
    {
        Administrator,
        User
    }
}
