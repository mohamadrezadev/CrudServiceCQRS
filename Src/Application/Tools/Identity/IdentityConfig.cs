using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools.Identity
{
    public static class IdentityConfig
    {
        public static void ConfigureIdentityOptions( IdentityOptions options )
        {
            // User Options
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+";

            // Signin Options
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            // Password Options
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;

            // LockOut
            options.Lockout.AllowedForNewUsers = false;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            options.Lockout.MaxFailedAccessAttempts = 3;

            // Stores Options
            // options.Stores.MaxLengthForKeys = 10;
            options.Stores.ProtectPersonalData = false;
        }
    }
}
