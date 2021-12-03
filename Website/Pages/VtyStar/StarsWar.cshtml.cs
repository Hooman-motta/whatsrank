// 
using DbLayer.Context;
using DbLayer.Enums;

namespace Website.Pages.VtyStar {
    public class StarsWarModel : VtyStarWarBaseModel {
        public StarsWarModel (AppDbContext context) : base (VtyStarsWarType.StarsWar, context) { }
    }
}