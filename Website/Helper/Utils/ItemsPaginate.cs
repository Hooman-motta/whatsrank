namespace Website.Helper.Utils {
    public class ItemsPaginate<T> {
        private short _pageSize;

        public ItemsPaginate (T[] data, int page, int itemsCount, short pageSize = 10) {
            Page = page;
            FinalData = data;
            ItemsCount = itemsCount;
            this._pageSize = pageSize;

            PagesCount = (int) System.Math.Ceiling ((double) ItemsCount / pageSize);

            HasPrevious = PagesCount > 1 && Page > 1;
            HasNext = Page > PagesCount ? false : !int.Equals (PagesCount, Page);
        }

        public T[] FinalData { get; set; }

        public int Page { get; set; } = 1;

        public int PagesCount { get; set; }

        public int ItemsCount { get; set; }

        public bool HasNext { get; set; }

        public bool HasPrevious { get; set; }
    }
}