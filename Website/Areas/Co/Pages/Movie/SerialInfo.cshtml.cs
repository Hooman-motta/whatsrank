using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Entities;
using HpLayer.Attributes;
using HpLayer.Services;
using Website.Areas.Shared;
using Website.Helper.Utils;

namespace Website.Areas.Co.Pages.Movie {
    public class SerialInfoModel : RootPage<TblSerialInfo> {
        private const int w = 200;
        private const int h = 300;
        private static PgAddr pgAddr = new PgAddr {
            CreateName = "_SerialInfoCreate",
            redirectUrl = "./SerialInfo"
        };
        public SerialInfoModel (AppDbContext context, IUploadServices uploadServices) : base (context, uploadServices, pgAddr) { }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }

        public class InputModel {
            [Display (Name = "فصل")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public byte SeasonId { get; set; }

            [Display (Name = "قسمت")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public byte ChapterId { get; set; }

            [Display (Name = "تصویر : ")]
            [AllowedExtensions (new string[] { ".jpg", ".png", ".jpeg" })]
            [AttrRequestSizeLimit (ConstValues.UPLOAD_SIZE_IMAGE_IN_MB)]
            public IFormFile FormFile { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel {
            public long SeasonId { get; set; }

            public string Season { get; set; }

            public List<ChapterVm> Chapters { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGetAsync () {
            var list = new List<ListModel> ();
            var result = await _dbSet
                .Where (x => x.MovieId == Id && x.ParentId == null)
                .Include (x => x.Children).ThenInclude (x => x.TblSerialVote)
                .OrderBy (x => x.Parent.Number)
                .ToListAsync ();

            foreach (var item in result) {
                var seasons = new ListModel ();
                seasons.SeasonId = item.Id;
                seasons.Season = item.NumberTitle;
                var children = new List<ChapterVm> ();
                foreach (var child in item.Children) {
                    var chapter = new ChapterVm {
                        ChapterId = child.Id,
                        Chapter = child.NumberTitle,
                        FileUrl = child.FileUrl,
                        Vote = (decimal) child.TblSerialVote.Sum (x => x.Mark),
                        // check later
                        UserMark = child.TblSerialVote.Any (x => x.UserId != null) ?
                        child.TblSerialVote.First ().Mark : null
                    };
                    children.Add (chapter);
                }
                seasons.Chapters = children;
                list.Add (seasons);
            }
            List = list;
        }

        public async Task<IActionResult> OnPostAsync () {
            if (ModelState.IsValid) {
                try {
                    var selectedSeason = await _dbSet
                        .FirstOrDefaultAsync (x => x.MovieId == Id && x.Number == Input.SeasonId && x.ParentId == null);
                    if (selectedSeason != null) {
                        var alreadyChapter = await _dbSet
                            .AnyAsync (x => x.MovieId == Id && x.Number == Input.ChapterId && x.ParentId == selectedSeason.Id);
                        if (alreadyChapter) {
                            throw new Exception (ConstValues.ErAlready);
                        }
                        var serialInfo = new TblSerialInfo ();
                        if (Input.FormFile != null) {
                            var uploadFile = await _uploadServices
                                .SavePostedFileAsync (Input.FormFile, new BITMAPSIZE {
                                    W = w,
                                        H = h
                                });
                            serialInfo.FileUrl = uploadFile?.Item1;
                            serialInfo.ThumbnailsUrl = uploadFile?.Item2;
                        }
                        serialInfo.MovieId = Id;
                        serialInfo.ParentId = selectedSeason.Id;
                        serialInfo.Number = Input.ChapterId;
                        await AddItem (serialInfo);
                    }
                    // 
                    else {
                        var serialInfo = new TblSerialInfo ();
                        string fu = null, tu = null;
                        if (Input.FormFile != null) {
                            var uploadFile = await _uploadServices
                                .SavePostedFileAsync (Input.FormFile, new BITMAPSIZE {
                                    W = w,
                                        H = h
                                });
                            fu = uploadFile?.Item1;
                            tu = uploadFile?.Item2;
                        }
                        serialInfo.MovieId = Id;
                        serialInfo.Number = Input.SeasonId;
                        serialInfo.Children = new HashSet<TblSerialInfo> {
                            new TblSerialInfo {
                            Number = Input.ChapterId,
                            MovieId = Id,
                            FileUrl = fu,
                            ThumbnailsUrl = tu
                            }
                        };
                        await AddItem (serialInfo);
                    }
                    Alert = ModelStateType.A200.ModelStateAsText ();
                } catch (Exception ex) {
                    ModelState.AddModelError ("", ex.Message);
                    Alert = ModelState.ModelStateAsError ();
                }
            }
            return RedirectToPage (_pgAddr.redirectUrl);
        }

        // handler
        public PartialViewResult OnGetCreate () => base.HandlerCreate<InputModel> ();

        public async Task<IActionResult> OnPostRemove (long id) => await base.HandlerRemove (id);
    }
    public class ChapterVm {
        public long ChapterId { get; set; }

        public string Chapter { get; set; }

        public string FileUrl { get; set; }

        public decimal Vote { get; set; }

        public byte? UserMark { get; set; }
    }
}