using Application.Tools.Identity;
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
