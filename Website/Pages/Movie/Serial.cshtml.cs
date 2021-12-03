// 
using DbLayer.Context;
using DbLayer.Enums;

namespace Website.Pages.Movie {
    public class SerialModel : MovieBaseModel {
        public SerialModel (AppDbContext context) : base (MovieType.Serial, context) { }
    }
}