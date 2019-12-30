using DebtorWebApp.Areas.Identity.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DebtorWebApp.ServiceConfiguration
{
    public static class DefaultAdminConfiguration
    {

        public static async Task Initialize(IServiceProvider serviceProvider, IConfiguration configuration) {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            
            IdentityResult identityResult;

            foreach(var role in Enum.GetNames(typeof(ApplicationRoles)))
            {
                if(!(await roleManager.RoleExistsAsync(role))){
                    identityResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            IdentityUser adminUser = new IdentityUser {
                UserName = configuration.GetSection("AdminUserSettings")["Email"],
                Email = configuration.GetSection("AdminUserSettings")["Email"]
            };

            string password = configuration.GetSection("AdminUserSettings")["Password"];

            IdentityUser foundUser = await userManager.FindByEmailAsync(adminUser.Email);

            if(null == foundUser)
            {
                IdentityResult createdUser = await userManager.CreateAsync(adminUser, password);

                if (createdUser.Succeeded) {
                    await userManager.AddToRoleAsync(adminUser, ApplicationRoles.Administrator.ToString());
                }
            }
    
    }

    }
}
