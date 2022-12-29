using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.CustomAuthorizationAttribute
{
    public class AuthorizeAgeOverAttribute : AuthorizeAttribute
    {
        const string PREFIX = "Over";
        public AuthorizeAgeOverAttribute(int age) => Age = age;
        public int Age
        {
            get
            {
                if
                (int.TryParse(Policy.Substring(PREFIX.Length),
                out var age))
                {
                    return age;
                }
                return default(int);
            }
            set
            {
                Policy = $"{PREFIX}{value.ToString()}";
            }
        }
    }
}
