// 
using DbLayer.Context;
using DbLayer.Enums;

namespace Website.Pages.Movie {
    public class IndexModel : MovieBaseModel {
        public IndexModel (AppDbContext context) : base (MovieType.Film, context) { }
    }
}