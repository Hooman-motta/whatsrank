using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// 
using DbLayer.Context;
using DbLayer.Identity;
using DbLayer.Interfaces;
using Website.Service.SrcIdentity.Configure;
using Website.Service.SrcIdentity.UserManager;

namespace Website.Service {
    public static class IServiceCollectionExtensions {
        public static IServiceCollection AddSrcLayerRepositories (this IServiceCollection services) {
            // dbcontext
            services.AddScoped<IUnitOfWork, AppDbContext> ();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor> ();
            services.AddScoped<IPrincipal> (provider => provider.GetService<IHttpContextAccessor> ()?.HttpContext?.User ?? ClaimsPrincipal.Current);

            // identity
            services.AddScoped<IdentityErrorDescriber, IyErrorDescriber> ();

            // services.AddScoped<ISecurityStampValidator, SecurityStampValidator<AppUser>> ();
            services.AddScoped<IAppUserManager, AppUserManager> ();
            services.AddScoped<UserManager<AppUser>, AppUserManager> ();

            services.AddScoped<IUserStore<AppUser>, UserStore<AppUser, IdentityRole, AppDbContext>> ();

            // base
            // services.AddScoped (typeof (IFetchRepository<>), typeof (FetchRepository<>));
            // services.AddScoped (typeof (IModifyRepository<>), typeof (ModifyRepository<>));

            // artist
            // services.AddScoped<IArtistRepository, ArtistRepository> ();
            // services.AddScoped<ICinemaRoleRepository, CinemaRoleRepository> ();

            // movie
            // services.AddScoped<IJenreRepository, JenreRepository> ();
            // services.AddScoped<IMovieRepository, MovieRepository> ();
            // services.AddScoped<IMovieVoteRepository, MovieVoteRepository> ();
            // services.AddScoped<IArtistVoteRepository, ArtistVoteRepository> ();
            // services.AddScoped<IAmrRepository, AmrRepository> ();
            // services.AddScoped<IArtistRepository, ArtistRepository> ();
            // services.AddScoped<ISerialInfoRepository, SerialInfoRepository> ();
            // services.AddScoped<ISerialVoteInfoRepository, SerialVoteInfoRepository> ();
            // services.AddScoped<IMovieRoleRepository, MovieRoleRepository> ();

            // vtystarswar
            // services.AddScoped<IVtyStarsWarRepository, VtyStarsWarRepository> ();
            // services.AddScoped<ICommentRepository, CommentRepository> ();
            // services.AddScoped<IVtyStarsWarOptionsRepository, VtyStarsWarOptionsRepository> ();

            // // jlover
            // services.AddScoped<IJustLoverRepository, JustLoverRepository> ();
            // services.AddScoped<IJustLoverAnswerRepository, JustLoverAnswerRepository> ();

            // tags
            // services.AddScoped<ITagsRepository, TagsRepository> ();

            return services;
        }
    }
}