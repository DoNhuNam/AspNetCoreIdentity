using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.SeedData
{
    public class SeedRole
    {
        public async Task SetupRoles(IServiceProvider serviceProvider)
        {
            var rolemanager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roles = { "Admin", "Support", "User" };
            foreach (var role in roles)
            {
                var roleExist = await rolemanager.
                RoleExistsAsync(role);
                if (!roleExist)
                {
                    await rolemanager.CreateAsync(new
                    IdentityRole(role));
                }
            }
        }
    }
}
