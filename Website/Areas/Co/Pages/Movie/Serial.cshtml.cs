// 
using DbLayer.Context;
using DbLayer.Enums;
using HpLayer.Services;
using Website.Areas.Shared;

namespace Website.Areas.Co.Pages.Movie {
    public class SerialModel : MovieBaseModel {
        private static PgAddr pgAddr = new PgAddr {
            CreateName = "_Create",
            redirectUrl = "./Serial"
        };
        public SerialModel (AppDbContext context, IUploadServices uploadServices) : base (MovieType.Serial, context, uploadServices, pgAddr) { }
    }
}