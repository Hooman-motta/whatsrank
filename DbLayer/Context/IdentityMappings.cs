using DbLayer.Identity;
using Microsoft.EntityFrameworkCore;

//

namespace DbLayer.Context {
    public static class IdentityMappings {
        /// <summary>
        /// Adds all of the ASP.NET Core Identity related mappings at once.
        /// More info: http://www.dotnettips.info/post/2577
        /// and http://www.dotnettips.info/post/2578
        /// </summary>
        public static void AddIdentityMappings (this ModelBuilder modelBuilder) {
            // modelBuilder.Entity<AppUser> (builder => {
            //     builder.ToTable ("AppUser");
            //     // Set unique personal code field
            //     // .HasIndex (x => x.PersonalCode).IsUnique ();
            // });

            // modelBuilder.Entity<AppRole> (builder => {
            //     builder.ToTable ("AppRole");
            // });

            // modelBuilder.Entity<AppUserRole> (builder => {
            //     builder.HasOne (userRole => userRole.AppRole).WithMany (role => role.AppUserRole).HasForeignKey (userRole => userRole.RoleId);
            //     builder.HasOne (userRole => userRole.AppUser).WithMany (user => user.AppUserRole).HasForeignKey (userRole => userRole.UserId);
            //     builder.ToTable ("AppUserRole");
            // });

            // modelBuilder.Entity<AppUserClaim> (builder => {
            //     builder.HasOne (userClaim => userClaim.AppUser).WithMany (user => user.AppUserClaim).HasForeignKey (userClaim => userClaim.UserId);
            //     builder.ToTable ("AppUserClaim");
            // });

            // modelBuilder.Entity<AppRoleClaim> (builder => {
            //     builder.HasOne (roleClaim => roleClaim.AppRole).WithMany (role => role.AppRoleClaim).HasForeignKey (roleClaim => roleClaim.RoleId);
            //     builder.ToTable ("AppRoleClaim");
            // });

            // modelBuilder.Entity<AppUserLogin> (builder => {
            //     builder.HasOne (userLogin => userLogin.AppUser).WithMany (user => user.AppUserLogin).HasForeignKey (userLogin => userLogin.UserId);
            //     builder.ToTable ("AppUserLogin");
            // });

            // modelBuilder.Entity<AppUserToken> (builder => {
            //     builder.HasOne (userToken => userToken.AppUser).WithMany (user => user.AppUserToken).HasForeignKey (userToken => userToken.UserId);
            //     builder.ToTable ("AppUserToken");
            // });

            // modelBuilder.Entity<TblUsersUsedPassword> (builder => {
            //     builder.ToTable ("TblUsersUsedPassword");
            //     builder.Property (applicationUserUsedPassword => applicationUserUsedPassword.HashedPassword)
            //         .HasMaxLength (450).IsRequired ();
            //     builder.HasOne (applicationUserUsedPassword => applicationUserUsedPassword.TblUsers)
            //         .WithMany (applicationUser => applicationUser.TblUsersUsedPassword);
            // });

            // modelBuilder.Entity<TblAppSqlCache> (builder => {
            //     // For Microsoft.Extensions.Caching.SqlServer
            //     var cacheOptions = siteSettings.CookieOptions.DistributedSqlServerCacheOptions;
            //     builder.ToTable (cacheOptions.TableName, cacheOptions.SchemaName);
            //     builder.HasIndex (e => e.ExpiresAtTime).HasName ("Index_ExpiresAtTime");
            //     builder.Property (e => e.Id).HasMaxLength (449);
            //     builder.Property (e => e.Value).IsRequired ();
            // });

            // modelBuilder.Entity<TblAppDataProtectionKey> (builder => {
            //     builder.ToTable ("TblAppDataProtectionKey");
            //     builder.HasIndex (e => e.FriendlyName).IsUnique ();
            // });
        }
    }
}