using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

// 

namespace Website.Service.SrcIdentity {
    public static class IdentityConfigure {
        public static void IdentityConfiguration (IdentityOptions options) {
            UserOptions (options.User);
            SignInOptions (options.SignIn);
            LockoutOptions (options.Lockout);
            PasswordOptions (options.Password);
        }

        private static void UserOptions (UserOptions options) {
            options.RequireUniqueEmail = false;
            options.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        }

        private static void SignInOptions (SignInOptions options) {
            options.RequireConfirmedEmail = false;
            options.RequireConfirmedPhoneNumber = false;
            options.RequireConfirmedAccount = false;
        }

        private static void LockoutOptions (LockoutOptions options) {
            options.AllowedForNewUsers = true;
            options.MaxFailedAccessAttempts = 5;
        }

        private static void PasswordOptions (PasswordOptions options) {
            options.RequireDigit = false;
            options.RequireLowercase = false;
            options.RequireNonAlphanumeric = false;
            options.RequireUppercase = false;
            options.RequiredLength = 5;
        }

        // public static IServiceCollection AddIdentityConfigure (this IServiceCollection services, IConfiguration configuration) {
        //     // Configure DbContext with Scoped lifetime   
        //     services.AddDbContext<AppDbContext> (options => {
        //         options.UseSqlServer (
        //             configuration["ConnectionStrings:DefaultConnection"],
        //             serverDbContextOptionsBuilder => {
        //                 var minutes = (int) TimeSpan.FromMinutes (3).TotalSeconds;
        //                 serverDbContextOptionsBuilder.CommandTimeout (minutes);
        //                 serverDbContextOptionsBuilder.EnableRetryOnFailure ();
        //                 serverDbContextOptionsBuilder.MigrationsAssembly ("Website");
        //             }
        //         );
        //     });

        //     services.AddIdentity<AppUser, IdentityRole>
        //         (options => {
        //             UserOptions (options.User);
        //             SignInOptions (options.SignIn);
        //             LockoutOptions (options.Lockout);
        //             PasswordOptions (options.Password);
        //         })
        //         .AddUserManager<AppUserManager> ()
        //         .AddSignInManager<SignInManager<AppUser>> ()
        //         .AddErrorDescriber<IyErrorDescriber> ()
        //         .AddDefaultTokenProviders ();
        //     // services.Configure<SecurityStampValidatorOptions> (options => {
        //     //     options.ValidationInterval = TimeSpan.FromMinutes (2);
        //     // });

        //     services.ConfigureApplicationCookie (identityOptionsCookies => {
        //         SetApplicationCookieOptions (identityOptionsCookies);
        //     });

        //     return services;
        // }
    }
}