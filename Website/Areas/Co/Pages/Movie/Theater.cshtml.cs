// 
using DbLayer.Context;
using DbLayer.Enums;
using HpLayer.Services;
using Website.Areas.Shared;

namespace Website.Areas.Co.Pages.Movie {
    public class TheaterModel : MovieBaseModel {
        private static PgAddr pgAddr = new PgAddr {
            CreateName = "_Create",
            redirectUrl = "./Theater"
        };
        public TheaterModel (AppDbContext context, IUploadServices uploadServices) : base (MovieType.Theater, context, uploadServices, pgAddr) { }
    }
}