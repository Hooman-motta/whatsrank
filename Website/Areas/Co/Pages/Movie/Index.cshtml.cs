// 
using DbLayer.Context;
using DbLayer.Enums;
using HpLayer.Services;
using Website.Areas.Shared;

namespace Website.Areas.Co.Pages.Movie {
    public class IndexModel : MovieBaseModel {
        private static PgAddr pgAddr = new PgAddr {
            CreateName = "_Create",
            redirectUrl = "./Index"
        };
        public IndexModel (AppDbContext context, IUploadServices uploadServices) : base (MovieType.Film, context, uploadServices, pgAddr) { }
    }
}