using System;

// 
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Service.SrcIdentity.Vmodel {
    public class UserVm : VoteHelperVm {

        public string Id { get; set; }

        public string Avatar { get; set; }

        public string DisplayName { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime DateCreated { get; set; }

        public string PersianDateCreated { get; set; }

        public string Roles { get; set; }

        public string Province { get; set; }
    }

    public class UserPaginateVm : ItemsPaginate<UserVm> {
        public UserPaginateVm (UserVm[] list, int page, int itemsCount) : base (list, page, itemsCount) { }
    }

    public class UserInfoVm : UserVm {
        public string Bio { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Education { get; set; }

        public byte? UserMark { get; set; } = null;
    }

    public class UserResumeVm {
        public long Id { get; set; }

        public string Title { get; set; }

        public string VideoUrl { get; set; }
    }
}