using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// 
using CldLayer.Persian;
using DbLayer.Context;
using DbLayer.Identity;
using DbLayer.Interfaces;
using Website.Helper.Utils;
using Website.Helper.Vmodel;
using Website.Service.SrcIdentity.Configure;
using Website.Service.SrcIdentity.Vmodel;

namespace Website.Service.SrcIdentity.UserManager {
    public class AppUserManager : UserManager<AppUser>, IAppUserManager {
        private AppUser _currentUserInScope;
        private readonly DbSet<AppUser> _users;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        // IUserStore<AppUser>
        // private readonly IAppUserStore _appUserStore;
        private readonly IUserStore<AppUser> _appUserStore;

        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IEnumerable<IUserValidator<AppUser>> _userValidators;
        private readonly IEnumerable<IPasswordValidator<AppUser>> _passwordValidators;
        private readonly ILookupNormalizer _keyNormalizer;
        private readonly IdentityErrorDescriber _errors;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AppUserManager> _logger;

        public AppUserManager (
            IUnitOfWork unitOfWork,
            IHttpContextAccessor contextAccessor,
            // 
            IUserStore<AppUser> appUserStore,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<AppUser> passwordHasher,
            IEnumerable<IUserValidator<AppUser>> userValidators,
            IEnumerable<IPasswordValidator<AppUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider serviceProvider,
            ILogger<AppUserManager> logger) : base ((UserStore<AppUser, IdentityRole, AppDbContext>) appUserStore, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, serviceProvider, logger) {

            _unitOfWork = unitOfWork;
            _users = _unitOfWork.Set<AppUser> ();
            _contextAccessor = contextAccessor;

            // 
            _appUserStore = appUserStore;
            _optionsAccessor = optionsAccessor;
            _passwordHasher = passwordHasher;
            _userValidators = userValidators;
            _passwordValidators = passwordValidators;
            _keyNormalizer = keyNormalizer;
            _errors = errors;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        #region :: Extra methods ::
        public AppUser GetCurrentUser () {
            if (_currentUserInScope != null) {
                return _currentUserInScope;
            }
            if (string.IsNullOrWhiteSpace (CurrentUserId)) {
                return null;
            }
            return _currentUserInScope = FindById (CurrentUserId);
        }

        public Task<List<AppUser>> GetAllUsersAsync () {
            return Users.ToListAsync ();
        }

        public async Task<AppUser> GetCurrentUserAsync () {
            var user = _currentUserInScope;
            if (user == null) {
                user = await GetUserAsync (_contextAccessor.HttpContext.User);
                user.Avatar = user.Avatar.ToFriendlyImage (DefaultImageType.DEF_AVATAR);
            }
            return user;
        }

        public AppUser FindById (string userId) => _users.Find (userId);

        public async Task<int> GetUserCount () => await _users.CountAsync ();

        private string CurrentUserId => _contextAccessor.HttpContext.User.Identity.GetUserId ();

        private string GetCurrentUserName => _contextAccessor.HttpContext.User.Identity.GetUserName ();

        IQueryable<AppUser> IAppUserManager.Users => base.Users;

        IList<IUserValidator<AppUser>> IAppUserManager.UserValidators => base.UserValidators;

        IList<IPasswordValidator<AppUser>> IAppUserManager.PasswordValidators => base.PasswordValidators;

        IPasswordHasher<AppUser> IAppUserManager.PasswordHasher { get => base.PasswordHasher; set => base.PasswordHasher = value; }

        public async Task<bool> HasPasswordAsync (string userId) {
            var user = await FindByIdAsync (userId);
            return user?.PasswordHash != null;
        }

        public async Task<bool> HasPhoneNumberAsync (string userId) {
            var user = await FindByIdAsync (userId);
            return user?.PhoneNumber != null;
        }

        public async Task<UserPaginateVm> FetchUserAsync (FilterQs vm) {
            const int pageSize = 10;
            if (!string.IsNullOrEmpty (vm.Filter)) {
                var userCount = await _users.CountAsync (x => x.UserName.Contains (vm.Filter));
                var lastSignUpedUsers = await _users.Where (x => x.UserName.Contains (vm.Filter))
                    .Select (x => new UserVm {
                        Id = x.Id,
                            // Avatar = x.Avatar,
                            DisplayName = x.DisplayName,
                            IsAvailable = x.IsAvailable,
                            DateCreated = x.DateCreated,
                            PersianDateCreated = x.DateCreated.ToLongPersianDateString (),
                            // VoteAverage = x.UserVoted.Any () ? x.UserVoted.Average (x => x.Mark) : 0,
                            // Province = x.ProvinceId.HasValue ? $"{x.TblProvince.Title} , {x.TblProvince.Parent.Title}" : "---",
                            // Roles = x.TblUserCinemaRole.Any () ? String.Join (" , ", x.TblUserCinemaRole.Select (x => x.CinemaRole.Title)) : "---"
                    }).Skip ((vm.P - 1) * pageSize).Take (pageSize)
                    .OrderByDescending (x => x.DateCreated).ToListAsync ();
                return new UserPaginateVm (lastSignUpedUsers.ToArray (), vm.P, userCount);
            } else {
                var userCount = await _users.CountAsync ();
                var lastSignUpedUsers = await _users.Select (x => new UserVm {
                        Id = x.Id,
                            // Avatar = x.Avatar,
                            DisplayName = x.DisplayName,
                            IsAvailable = x.IsAvailable,
                            DateCreated = x.DateCreated,
                            PersianDateCreated = x.DateCreated.ToLongPersianDateString (),
                            // VoteAverage = x.UserVoted.Any () ? x.UserVoted.Average (x => x.Mark) : 0,
                            // Province = x.ProvinceId.HasValue ? $"{x.TblProvince.Title} , {x.TblProvince.Parent.Title}" : "---",
                            // Roles = x.TblUserCinemaRole.Any () ? String.Join (" , ", x.TblUserCinemaRole.Select (x => x.CinemaRole.Title)) : "---"
                    }).Skip ((vm.P - 1) * pageSize).Take (pageSize)
                    .OrderByDescending (x => x.DateCreated).ToListAsync ();
                return new UserPaginateVm (lastSignUpedUsers.ToArray (), vm.P, userCount);
            }
        }

        public async Task<List<UserResumeVm>> FetchUserResumeAsync (string userId) {
            var user = await _users
                .Include (x => x.TblUserResume).SingleAsync (x => x.Id == userId);
            var result = new List<UserResumeVm> ();
            foreach (var item in user.TblUserResume) {
                var newItem = new UserResumeVm ();
                result.Add (new UserResumeVm {
                    Id = item.Id,
                        Title = item.Title,
                        VideoUrl = item.VideoUrl
                });
            }
            return result;
        }

        public async Task<UserInfoVm> FetchUserInfoUIAsync (string userId, string loggedUserId = null) {
            // return await _users
            //     .Include (x => x.userId)
            //     .Include (x => x.TblProvince).ThenInclude (x => x.Parent)
            //     .Include (x => x.TblUserCinemaRole).ThenInclude (x => x.TblCinemaRole)
            //     .Select (x => new UserInfoVm {
            //         Id = x.Id,
            //             DisplayName = x.DisplayName,
            //             IsAvailable = x.IsAvailable,
            //             Avatar = x.Avatar.ToFriendlyImage (DefaultImageType.DEF_AVATAR),
            //             Roles = x.TblUserCinemaRole.Any () ? String.Join (" , ", x.TblUserCinemaRole.Select (x => x.TblCinemaRole.Title)) : "---",
            //             Province = x.ProvinceId.HasValue ? $"{x.TblProvince.Title} , {x.TblProvince.Parent.Title}" : "---",
            //             VoteCount = x.WhoVoted.Count (),
            //             VoteAverage = x.WhoVoted.Any () ? x.WhoVoted.Average (x => x.Mark) : 0,
            //             Bio = x.Bio,
            //             Email = x.Email,
            //             PhoneNumber = x.PhoneNumber ?? "---",
            //             Education = x.EducationTitle ?? "---",
            //             UserMark = x.WhoVoted.Any (x => x.VoterId == loggedUserId) ?
            //             x.WhoVoted.FirstOrDefault (y => y.VoterId == loggedUserId).Mark : null
            //     }).SingleAsync (x => x.Id == userId);
            return null;
        }

        public async Task<UserPaginateVm> FetchUserInfoUIAsync (int page = 1, long[] p = null, long[] c = null) {
            const int pageSize = 20;
            var user = _users.AsQueryable ();
            if (p.Any ()) {
                user = user.Where (x => p.Contains (x.TblProvince.Parent.Id))
                    .Include (x => x.TblProvince).ThenInclude (x => x.Parent).AsQueryable ();
            } else {
                user = user.Include (x => x.TblProvince)
                    .ThenInclude (x => x.Parent).AsQueryable ();
            }
            if (c.Any ()) {
                user = user.Where (x => x.TblUserCinemaRole.Any (y => c.Contains (y.CinemaRoleId)))
                    .Include (x => x.TblUserCinemaRole).ThenInclude (x => x.TblCinemaRole).AsQueryable ();
            } else {
                user = user.Include (x => x.TblUserCinemaRole).ThenInclude (x => x.TblCinemaRole).AsQueryable ();
            }

            // var sql = user.ToQueryString ();
            var userCount = await user.CountAsync ();
            var lastSignUpedUsers = await user
                .Select (x => new UserVm {
                    Id = x.Id,
                        DisplayName = x.DisplayName,
                        IsAvailable = x.IsAvailable,
                        DateCreated = x.DateCreated,
                        Avatar = x.Avatar.ToFriendlyImage (DefaultImageType.DEF_AVATAR),
                        Roles = x.TblUserCinemaRole.Any () ? String.Join (" , ", x.TblUserCinemaRole.Select (x => x.TblCinemaRole.Title)) : "---",
                        // VoteAverage = x.WhoVoted.Any () ? x.WhoVoted.Average (x => x.Mark) : 0,
                        Province = x.ProvinceId.HasValue ? $"{x.TblProvince.Title} , {x.TblProvince.Parent.Title}" : "---"
                }).Skip ((page - 1) * pageSize).Take (pageSize).OrderByDescending (x => x.DateCreated).ToListAsync ();
            return new UserPaginateVm (lastSignUpedUsers.ToArray (), page, userCount);
        }

        public async Task<List<CinemaRoleVm>> FetchCurrentUserCinemaRoleAsync () {
            var cinemaRole = await _users.Include (x => x.TblUserCinemaRole)
                .ThenInclude (x => x.TblCinemaRole).FirstOrDefaultAsync (x => x.Id == CurrentUserId);
            var result = new List<CinemaRoleVm> ();
            foreach (var item in cinemaRole.TblUserCinemaRole) {
                result.Add (new CinemaRoleVm {
                    Id = item.CinemaRoleId,
                        Role = item.TblCinemaRole.Title
                });
            }
            return result;
        }
        #endregion
    }
}