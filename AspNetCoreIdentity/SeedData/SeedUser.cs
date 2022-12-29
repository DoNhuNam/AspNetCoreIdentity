using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.SeedData
{
    public class SeedUser
    {
        public async Task SetUpUsers(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var adminUser = await userManager.
            FindByEmailAsync("admin@abc.com");
            if (adminUser == null)
            {
                var newAdminUser = new IdentityUser
                {
                    UserName = "admin@abc.com",
                    Email = "admin@abc.com",
                };
                var result = await userManager
                .CreateAsync(newAdminUser, "Password@123");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(newAdminUser,
                    "Admin");
            }
            var supportUser = await userManager
            .FindByEmailAsync("support@abc.com");
            if (supportUser == null)
            {
                var newSupportUser = new IdentityUser
                {
                    UserName = "support@abc.com",
                    Email = "support@abc.com",
                };
                var result = await userManager
                .CreateAsync(newSupportUser, "Password@123");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(newSupportUser,
                    "Support");
            }
        }
    }
}
