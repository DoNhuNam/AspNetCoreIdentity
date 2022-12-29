using AspNetCoreIdentity.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.CustomAuthorization
{
    public class MinimumAgePolicyProvider : IAuthorizationPolicyProvider
    {
        private DefaultAuthorizationPolicyProvider BackupPolicyProvider { get; }
        const string PREFIX = "Over";

        public MinimumAgePolicyProvider(IOptions<AuthorizationOptions> options)
        {
            this.BackupPolicyProvider =
            new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(PREFIX, StringComparison.OrdinalIgnoreCase) && int.TryParse(policyName.Substring(PREFIX.Length), out var age))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new MinimumAgeRequirement(age));
                return Task.FromResult<AuthorizationPolicy?>(policy.Build());
            }
            return
            Task.FromResult<AuthorizationPolicy?>(null);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return this.BackupPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            return this.BackupPolicyProvider.GetFallbackPolicyAsync();
        }
    }
}
