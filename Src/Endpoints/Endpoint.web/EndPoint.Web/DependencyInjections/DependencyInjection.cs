using Application.Tools;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistances.Contexts;
using System;

namespace EndPoint.Web.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices( this IServiceCollection Services )
        {
            Services.AddIdentity<User, Role>(options =>
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
                 //options.Stores.MaxLengthForKeys = 10;
                 options.Stores.ProtectPersonalData = false;


             })
                .AddUserManager<UserManager<User>>()
                .AddRoles<Role>() 
                .AddDefaultTokenProviders()
                .AddErrorDescriber<PersianIdentityErrors>()
                .AddRoleManager<RoleManager<Role>>() // Add this line if you are using custom roles (Role class).
                .AddEntityFrameworkStores<AppDbContext>();
            Services.AddAuthentication()
                .AddCookie();
           Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromDays(1);
            });
            Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LoginPath = "/Account/login";
                options.LogoutPath = "/Account/logout";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(3);
            });
            Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            return Services;
        }
    }
}
