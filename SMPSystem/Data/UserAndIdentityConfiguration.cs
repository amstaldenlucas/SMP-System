using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SMPSystem.Models;
using System;

namespace SMPSystem.Data
{
    public static class UserAndIdentityConfiguration
    {
        internal static IServiceCollection ConfigureUserAndIdentity(this IServiceCollection services)
        {
            services.AddIdentity<DbUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.AllowedForNewUsers = true;
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._-@";
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
