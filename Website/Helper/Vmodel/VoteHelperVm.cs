namespace Website.Helper.Vmodel {
    public class VoteHelperVm {
        public int VoteCount { get; set; } = 0;

        public double SortType { get; set; } = 0;

        public double VoteAverage { get; set; } = 0;

        public string DisplayVoteAverage => VoteAverage != 0 ? string.Format ("{0:0.00}", VoteAverage) : "0";
    }
}