using DbLayer.Context;
using DbLayer.Enums;

namespace Website.Pages.VtyStar {
    public class IndexModel : VtyStarWarBaseModel {
        public IndexModel (AppDbContext context) : base (VtyStarsWarType.Vty, context) { }
    }
}