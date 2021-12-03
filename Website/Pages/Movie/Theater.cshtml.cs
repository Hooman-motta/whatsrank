// 
using DbLayer.Context;
using DbLayer.Enums;

namespace Website.Pages.Movie {
    public class TheaterModel : MovieBaseModel {
        public TheaterModel (AppDbContext context) : base (MovieType.Theater, context) { }
    }
}