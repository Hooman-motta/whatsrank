using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//
using DbLayer.Context;
using DbLayer.Helper;
using DbLayer.Identity;
using HpLayer;
using HpLayer.Services;
using Website.Service.SrcIdentity;

namespace Website {
    public class Startup {
        public Startup (IConfiguration configure) {
            Configuration = configure;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            // services.Configure<CookiePolicyOptions> (options => {
            //     // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //     options.CheckConsentNeeded = context => true;
            //     options.MinimumSameSitePolicy = SameSiteMode.Strict;
            // });

            services.AddDbContext<AppDbContext> (options =>
                options.UseSqlServer (
                    Configuration["ConnectionStrings:DefaultConnection"],
                    optionsBuilder => {
                        optionsBuilder.MigrationsAssembly ("Website");
                    }
                ));

            // services.AddScoped<IUnitOfWork, AppDbContext> ();
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor> ();

            services.AddIdentity<AppUser, IdentityRole> (options => {
                    IdentityConfigure.IdentityConfiguration (options);
                }).AddEntityFrameworkStores<AppDbContext> ()
                .AddDefaultTokenProviders ();

            services.ConfigureApplicationCookie (options => {
                options.LoginPath = "/";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays (7);
                options.SlidingExpiration = true;
            });

            // HpLayer
            services.AddSingleton<IUploadServices, UploadServices> ();

            // 
            services.AddAuthorization (options => {
                options.AddPolicy (ConstRoles.Owner, authPolicy => {
                    authPolicy.RequireRole (ConstRoles.Owner);
                });
                options.AddPolicy (ConstRoles.Artist, authPolicy => {
                    authPolicy.RequireRole (ConstRoles.Artist);
                });
                options.AddPolicy (ConstRoles.User, authPolicy => {
                    authPolicy.RequireRole (ConstRoles.User);
                });
            });

            // razor pages
            services.AddRazorPages (options => {
                options.Conventions.AuthorizeFolder ("/Account")
                    .AllowAnonymousToPage ("/Account/Auth")
                    .AllowAnonymousToPage ("/Account/Login")
                    .AuthorizePage ("/Account/Resume", ConstRoles.Artist)
                    .AuthorizePage ("/Account/CinemaRole", ConstRoles.Artist);
                options.Conventions.AuthorizeAreaFolder ("Co", "/", ConstRoles.Owner);
            });

            // route configure
            services.Configure<RouteOptions> (options => {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
                options.LowercaseQueryStrings = true;
            });

            services.AddAntiforgery (opts => opts.Cookie.Name = "anticsrf");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
                app.UseStatusCodePagesWithReExecute ("/error/opps");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseRouting ();

            // app.UseCookiePolicy ();
            app.UseAuthentication ();
            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapRazorPages ();
            });
        }
    }
}