using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Entities;
using DbLayer.Enums;
using DbLayer.Helper;
using DbLayer.Identity;
using DbLayer.Interfaces;
using HpLayer.Extensions;

namespace DbLayer.Context {
    public class AppDbContext : IdentityDbContext<AppUser>, IUnitOfWork {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }
        // Movie
        public DbSet<TblMovie> TblMovie { get; set; }
        public DbSet<TblMovieVote> TblMovieVote { get; set; }
        public DbSet<TblSerialVote> TblSerialVote { get; set; }
        public DbSet<TblSerialInfo> TblSerialInfo { get; set; }
        public DbSet<TblJenre> TblJenre { get; set; }
        public DbSet<TblArtist> TblArtist { get; set; }
        public DbSet<TblArtistVote> TblArtistVote { get; set; }
        public DbSet<TblCinemaRole> TblCinemaRole { get; set; }
        public DbSet<TblArtistMovieRole> TblArtistMovieRole { get; set; }

        // Just lover
        public DbSet<TblJustLover> TblJustLover { get; set; }
        public DbSet<TblJustLoverWinner> TblJustLoverWinner { get; set; }
        public DbSet<TblJustLoverAnswers> TblJustLoverAnswers { get; set; }

        // VtyStarswar
        public DbSet<TblVtyStarsWar> TblVtyStarsWar { get; set; }
        public DbSet<TblComment> TblComment { get; set; }
        public DbSet<TblVtyStarsWarOptions> TblVtyStarsWarOptions { get; set; }

        // identity
        public DbSet<TblProvince> TblProvince { get; set; }
        public DbSet<TblUserVote> TblUserVote { get; set; }
        public DbSet<TblUserResume> TblUserResume { get; set; }

        public void MarkAsChanged<TEntity> (TEntity entity) where TEntity : class {
            Update (entity);
        }

        public void AddRange<TEntity> (IEnumerable<TEntity> entities) where TEntity : class {
            Set<TEntity> ().AddRange (entities);
        }

        public void RemoveRange<TEntity> (IEnumerable<TEntity> entities) where TEntity : class {
            Set<TEntity> ().RemoveRange (entities);
        }

        public override int SaveChanges () {
            ChangeTracker.DetectChanges ();
            // BeforSaveTriggers ();
            // for performance reasons, to avoid calling DetectChanges() again.
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges ();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override int SaveChanges (bool acceptAllChangesOnSuccess) {
            ChangeTracker.DetectChanges ();

            // BeforSaveTriggers ();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChanges (acceptAllChangesOnSuccess);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override Task<int> SaveChangesAsync (CancellationToken cancellationToken = new CancellationToken ()) {
            ChangeTracker.DetectChanges ();

            // BeforSaveTriggers ();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync (cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override Task<int> SaveChangesAsync (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken ()) {
            ChangeTracker.DetectChanges ();

            // BeforSaveTriggers ();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync (acceptAllChangesOnSuccess, cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        #region :: Comment ::
        // public void ExecuteSqlCommand (string query) {
        //     Database.ExecuteSqlRaw (query);
        // }

        // public void ExecuteSqlCommand (string query, params object[] parameters) {
        //     Database.ExecuteSqlCommand (query, parameters);
        // }

        // public object GetShadowPropertyValue (object entity, string propertyName) {
        //     return this.Entry (entity).Property (propertyName).CurrentValue;
        // }

        // public T GetShadowPropertyValue<T> (object entity, string propertyName) where T : IConvertible {
        //     var value = this.Entry (entity).Property (propertyName).CurrentValue;
        //     return value != null ?
        //         (T) Convert.ChangeType (value, typeof (T), CultureInfo.InvariantCulture) :
        //         default (T);
        // }

        // private void BeforSaveTriggers () {
        //     ValidateEntities ();
        //     SetShadowProperties ();
        //     // this.ApplyCorrectYeKe ();
        // }

        // private void ValidateEntities () {
        //     var errors = this.GetValidationErrors ();
        //     if (!string.IsNullOrWhiteSpace (errors)) {
        //         // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
        //         var loggerFactory = this.GetService<ILoggerFactory> ();
        //         loggerFactory.DoArgumentNull (nameof (loggerFactory));
        //         var logger = loggerFactory.CreateLogger<ApplicationDbContext> ();
        //         logger.LogError (errors);
        //         throw new InvalidOperationException (errors);
        //     }
        // }

        // private void SetShadowProperties () {
        //     // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
        //     var httpContextAccessor = this.GetService<IHttpContextAccessor> ();
        //     httpContextAccessor.DoArgumentNull (nameof (httpContextAccessor));
        //     ChangeTracker.SetAuditableEntityPropertyValues (httpContextAccessor);
        // }
        #endregion

        protected override void OnModelCreating (ModelBuilder builder) {
            #region ### artist ###
            builder.Entity<TblArtistCinemaRole> ()
                .HasKey (x => new { x.CinemaRoleId, x.ArtistId });
            builder.Entity<TblArtistCinemaRole> ()
                .HasOne (a => a.TblArtist)
                .WithMany (ar => ar.TblArtistCinemaRole)
                .HasForeignKey (a => a.ArtistId)
                .OnDelete (DeleteBehavior.Cascade);
            builder.Entity<TblArtistCinemaRole> ()
                .HasOne (r => r.TblCinemaRole)
                .WithMany (ar => ar.TblArtistCinemaRole)
                .HasForeignKey (r => r.CinemaRoleId)
                .OnDelete (DeleteBehavior.Cascade);

            // artist vote
            builder.Entity<TblArtistVote> ()
                .HasOne (p => p.TblArtistMovieRole)
                .WithMany (b => b.TblArtistVote)
                .HasForeignKey (p => p.ArtistMovieRoleId)
                .OnDelete (DeleteBehavior.Cascade);
            builder.Entity<TblArtistVote> ()
                .HasOne (p => p.AppUser)
                .WithMany (b => b.TblArtistVote)
                .HasForeignKey (p => p.UserId)
                .OnDelete (DeleteBehavior.Cascade);

            foreach (var e in Enum.GetValues (typeof (CinemaRoleType)).Cast<CinemaRoleType> ()) {
                builder.Entity<TblCinemaRole> ().HasData (new TblCinemaRole { Id = (byte) e, Type = (byte) e, Title = EnumExtensions.GetDisplayName ((CinemaRoleType) e) });
            }
            #endregion

            #region :: justlover
            builder.Entity<TblJustLoverAnswers> ()
                .HasOne (o => o.TblJustLover).WithMany (m => m.TblJustLoverAnswers)
                .OnDelete (DeleteBehavior.Restrict);
            builder.Entity<TblJustLoverAnswers> ()
                .HasOne (o => o.AppUser).WithMany (m => m.TblJustLoverAnswers)
                .OnDelete (DeleteBehavior.Restrict);
            #endregion

            #region ### vty, warstars
            builder.Entity<TblVtyStarsWarTags> ()
                .HasKey (x => new { x.VtyStarsWarId, x.TagsId });
            builder.Entity<TblVtyStarsWarTags> ()
                .HasOne (a => a.TblVtyStarsWar)
                .WithMany (ar => ar.TblVtyStarsWarTags)
                .HasForeignKey (a => a.VtyStarsWarId)
                .OnDelete (DeleteBehavior.Cascade);
            builder.Entity<TblVtyStarsWarTags> ()
                .HasOne (r => r.TblTags)
                .WithMany (ar => ar.TblVtyStarsWarTags)
                .HasForeignKey (r => r.TagsId)
                .OnDelete (DeleteBehavior.Cascade);

            builder.Entity<TblVtyStarWarUserVote> ()
                .HasKey (x => new { x.UserId, x.VtyStarsWarOptionsId });
            builder.Entity<TblVtyStarWarUserVote> ()
                .HasOne (a => a.TblVtyStarsWarOptions)
                .WithMany (ar => ar.TblVtyStarWarUserVote)
                .HasForeignKey (a => a.VtyStarsWarOptionsId)
                .OnDelete (DeleteBehavior.Cascade);
            builder.Entity<TblVtyStarWarUserVote> ()
                .HasOne (r => r.AppUser)
                .WithMany (ar => ar.TblVtyStarWarUserVote)
                .HasForeignKey (r => r.UserId)
                .OnDelete (DeleteBehavior.Cascade);
            #endregion

            #region ### movie ###
            builder.Entity<TblMovieJenre> ().HasKey (x => new { x.JenreId, x.MovieId });
            builder.Entity<TblMovieJenre> ()
                .HasOne (a => a.TblJenre)
                .WithMany (ar => ar.TblMovieJenre)
                .HasForeignKey (a => a.JenreId)
                .OnDelete (DeleteBehavior.Cascade);
            builder.Entity<TblMovieJenre> ()
                .HasOne (r => r.TblMovie)
                .WithMany (ar => ar.TblMovieJenre)
                .HasForeignKey (r => r.MovieId)
                .OnDelete (DeleteBehavior.Cascade);

            // movie vs vote
            builder.Entity<TblMovieVote> ()
                .HasOne (a => a.TblMovie)
                .WithMany (ar => ar.TblMovieVote)
                .HasForeignKey (a => a.MovieId)
                .OnDelete (DeleteBehavior.Cascade);
            builder.Entity<TblMovieVote> ()
                .HasOne (r => r.AppUser)
                .WithMany (ar => ar.TblMovieVote)
                .HasForeignKey (r => r.UserId)
                .OnDelete (DeleteBehavior.Cascade);

            // movie vs tags
            builder.Entity<TblMovieTags> ().HasKey (x => new { x.MovieId, x.TagsId });
            builder.Entity<TblMovieTags> ()
                .HasOne (a => a.TblMovie)
                .WithMany (ar => ar.TblMovieTags)
                .HasForeignKey (a => a.MovieId)
                .OnDelete (DeleteBehavior.Cascade);
            builder.Entity<TblMovieTags> ()
                .HasOne (r => r.TblTags)
                .WithMany (ar => ar.TblMovieTags)
                .HasForeignKey (r => r.TagsId)
                .OnDelete (DeleteBehavior.Cascade);

            // serial
            builder.Entity<TblSerialInfo> ()
                .HasOne (p => p.Parent)
                .WithMany (b => b.Children)
                .HasForeignKey (p => p.ParentId);
            #endregion

            #region ### jenre ###
            foreach (var e in Enum.GetValues (typeof (JenreType)).Cast<JenreType> ()) {
                builder.Entity<TblJenre> ().HasData (new TblJenre { Id = (long) e, Type = e, Title = EnumExtensions.GetDisplayName ((JenreType) e) });
            }
            #endregion

            #region ### identity ###
            var AdminRoleId = Guid.NewGuid ().ToString ();
            var ArtistRoleId = Guid.NewGuid ().ToString ();
            var UserRoleId = Guid.NewGuid ().ToString ();
            builder.Entity<IdentityRole> ().HasData (new IdentityRole {
                Id = AdminRoleId,
                    Name = ConstRoles.Owner,
                    NormalizedName = ConstRoles.Owner
            });
            builder.Entity<IdentityRole> ().HasData (new IdentityRole {
                Id = ArtistRoleId,
                    Name = ConstRoles.Artist,
                    NormalizedName = ConstRoles.Artist
            });
            builder.Entity<IdentityRole> ().HasData (new IdentityRole {
                Id = UserRoleId,
                    Name = ConstRoles.User,
                    NormalizedName = ConstRoles.User
            });

            var AdminUserId = Guid.NewGuid ().ToString ();
            var hasher = new PasswordHasher<AppUser> ();
            builder.Entity<AppUser> ().HasData (new AppUser {
                Id = AdminUserId,
                    UserName = "mehrshad",
                    NormalizedUserName = "mehrshad",
                    Email = "mehrshad@gmail.com",
                    NormalizedEmail = "mehrshad@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword (null, "admin12345"),
                    SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>> ().HasData (new IdentityUserRole<string> {
                RoleId = AdminRoleId,
                UserId = AdminUserId
            });

            builder.Entity<TblUserVote> ()
                .HasOne (o => o.AppUser).WithMany (m => m.TblUserVote)
                .OnDelete (DeleteBehavior.Cascade);

            builder.Entity<TblUserCinemaRole> ().HasKey (x => new { x.CinemaRoleId, x.UserId });
            builder.Entity<TblUserCinemaRole> ()
                .HasOne (a => a.TblCinemaRole)
                .WithMany (ar => ar.TblUserCinemaRole)
                .HasForeignKey (a => a.CinemaRoleId)
                .OnDelete (DeleteBehavior.Cascade);

            builder.Entity<TblUserCinemaRole> ()
                .HasOne (r => r.AppUser)
                .WithMany (ar => ar.TblUserCinemaRole)
                .HasForeignKey (r => r.UserId)
                .OnDelete (DeleteBehavior.Cascade);
            #endregion

            #region ### cascade setting ###
            // var cascadeFKs = builder.Model.GetEntityTypes ().SelectMany (t => t.GetForeignKeys ())
            //     .Where (fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            // foreach (var fk in cascadeFKs) {
            //     fk.DeleteBehavior = DeleteBehavior.Restrict;
            // }
            #endregion

            #region ### province ###
            var allProvince = ProvinceHelper.All ();
            builder.Entity<TblProvince> ()
                .HasOne (p => p.Parent)
                .WithMany (b => b.Towns)
                .HasForeignKey (p => p.ParentId);
            builder.Entity<TblProvince> ().HasData (allProvince);
            #endregion
            base.OnModelCreating (builder);
        }
    }
}