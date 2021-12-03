namespace Website.Helper.Utils {
    public static class ConstValues {
        public const int MAX_VOTE = 10;
        public const int PAGE_SIZE = 10;
        public const int UPLOAD_SIZE_IMAGE_IN_MB = 5 * 1024 * 1024;

        // ok
        public const string OkSave = "اطلاعات با موفقیت ذخیره گردید.";
        public const string OkRemove = "اطلاعات با موفقیت حذف گردید.";
        public const string OkUpdate = "اطلاعات با موفقیت ویرایش گردید.";

        // er
        public const string ErOnDependency = "It has some dependencies";
        public const string ErRequest = "درخواست شما با خطا مواجه شد.";
        public const string ErAlready = "درخواست شما پیشتر ثبت شده است.";
        public const string ErRemove = "درخواست حذف شما با خطا مواجه شد.";
        public const string ErOnFetchingData = "Some error occured on fetching data.";

        //  rq  
        public const string RqError = "اجباری می باشد";
        public const string RgError = "معتبر نمی باشد";
    }
}