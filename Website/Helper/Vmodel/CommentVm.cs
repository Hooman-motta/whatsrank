namespace Website.Helper.Vmodel {
    public class CommentVm {
        public long Id { get; set; }

        public string UserId { get; set; }

        public string PostType { get; set; }

        public string PostTitle { get; set; }

        public string Extract { get; set; }

        public bool IsApproved { get; set; }

        public string DisplayName { get; set; }

        public string PersianCreatedDate { get; set; }
    }
}