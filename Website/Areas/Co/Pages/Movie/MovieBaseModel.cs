using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// 
using CldLayer.Persian;
using DbLayer.Context;
using DbLayer.Entities;
using DbLayer.Enums;
using HpLayer.Attributes;
using HpLayer.Services;
using Website.Areas.Shared;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Areas.Co.Pages.Movie {
    public class MovieBaseModel : RootPage<TblMovie> {
        private const int w = 200;
        private const int h = 300;
        private readonly MovieType _type;
        public MovieBaseModel (MovieType type, AppDbContext context, IUploadServices uploadServices, PgAddr pgAddr) : base (context, uploadServices, pgAddr) {
            _type = type;
        }

        public class InputModel {
            public InputModel () {
                var jenreType = new List<JenreTypeVm> ();
                foreach (JenreType type in Enum.GetValues (typeof (JenreType))) {
                    jenreType.Add (new JenreTypeVm () { JenreType = type, Selected = false });
                }
                JenreTypes = jenreType;
            }
            public long? Id { get; set; }

            [Display (Name = "عنوان : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Title { get; set; }

            [Display (Name = "اکران : ")]
            public string ReleaseDate { get; set; }

            [StringLength (500)]
            [Display (Name = "کلمه کلیدی : ")]
            public string KeyWord { get; set; }

            [Display (Name = "برچسب : ")]
            public string Tags { get; set; }

            public string Source { get; set; }

            [Display (Name = "ساعت : ")]
            public short Hours { get; set; } = 0;

            [Display (Name = "دقیقه : ")]
            public short Minutes { get; set; } = 0;

            public TimeSpan Interval => TimeSpan.FromHours (Hours) + TimeSpan.FromMinutes (Minutes);

            public List<JenreTypeVm> JenreTypes { get; set; }

            [Display (Name = "تصویر : ")]
            [AllowedExtensions (new string[] { ".jpg", ".png", ".jpeg" })]
            [AttrRequestSizeLimit (ConstValues.UPLOAD_SIZE_IMAGE_IN_MB)]
            public IFormFile FormFile { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel : VoteHelperVm {
            public long Id { get; set; }

            public string Title { get; set; }

            public string ReleaseDate { get; set; }

            public string KeyWord { get; set; }

            public string Jenres { get; set; }

            public string FileUrl { get; set; }

            public string Interval { get; set; }

            public string PersianCreatedDate { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync ([FromQuery] FilterQs vm) {
            var entity = _dbSet
                .Where (x => x.Type == (byte) _type)
                .Include (x => x.TblMovieVote)
                .Include (x => x.TblMovieJenre)
                .ThenInclude (x => x.TblJenre).AsNoTracking ();
            if (!string.IsNullOrEmpty (vm.Filter)) {
                entity = _dbSet.Where (x => x.Title.Contains (vm.Filter));
            }
            List = await PaginatedList<ListModel>.CreateAsync (
                entity.OrderByDescending (x => x.Id)
                .Select (x => new ListModel {
                    Id = x.Id,
                        Title = x.Title,
                        Jenres = string.Join ('-', x.TblMovieJenre.Select (x => x.TblJenre.Title).ToArray ()),
                        FileUrl = x.FileUrl,
                        PersianCreatedDate = x.PersianCreatedDate,
                        ReleaseDate = x.ReleaseDate.ToLongPersianDateString (),
                        Interval = x.Interval.ToString (@"hh\:mm"),
                        KeyWord = x.KeyWord,
                        VoteCount = x.TblMovieVote.Count (),
                        VoteAverage = x.TblMovieVote.Any () ? x.TblMovieVote.Average (x => x.Mark) : 0,
                }), vm.P, _pageSize
            );
        }

        public async Task<IActionResult> OnPostAsync () {
            if (ModelState.IsValid) {
                try {
                    if (Input.Id.HasValue) {
                        var result = await _dbSet
                            .Include (x => x.TblMovieTags)
                            .Include (x => x.TblMovieJenre)
                            .FirstOrDefaultAsync (x => x.Id == Input.Id);

                        var ids = GetIdsByTags (Input.Tags);
                        var selectedJenres = Input.JenreTypes.Where (x => x.Selected).ToList ();
                        var deselectedJenres = Input.JenreTypes.Where (x => !x.Selected).ToList ();

                        if (Input.FormFile != null) {
                            _uploadServices.PhysicalDeleteFile (result.FileUrl);
                            _uploadServices.PhysicalDeleteFile (result.ThumbnailsUrl);
                            var uploaded = await _uploadServices.SavePostedFileAsync (Input.FormFile, new BITMAPSIZE {
                                W = w,
                                    H = h
                            });
                            result.FileUrl = uploaded?.Item1;
                            result.ThumbnailsUrl = uploaded?.Item2;
                        }

                        result.Title = Input.Title;
                        result.KeyWord = Input.KeyWord;
                        result.Source = Input.Source;
                        result.ReleaseDate = Input.ReleaseDate?.ToGregorianDateTimeOrDefault ();
                        result.Interval = Input.Interval;

                        // remove tags
                        var tagsRemove = result.TblMovieTags.Where (x => !ids.Any (y => y == x.TagsId));
                        foreach (var tag in tagsRemove) {
                            result.TblMovieTags.Remove (tag);
                        }

                        // add tags
                        var tagsAdd = ids.Where (x => !result.TblMovieTags.Any (y => y.TagsId == x));
                        foreach (var tag in tagsAdd) {
                            result.TblMovieTags
                                .Add (new TblMovieTags { TagsId = tag });
                        }

                        // remove jenres
                        var jenresRemove = result.TblMovieJenre
                            .Where (x => deselectedJenres.Any (y => (long) y.JenreType == x.JenreId)).ToList ();
                        foreach (var tag in jenresRemove) {
                            result.TblMovieJenre.Remove (tag);
                        }

                        // add jenres
                        var jenresAdd = selectedJenres.Where (x => !result.TblMovieJenre.Any (y => y.JenreId == (long) x.JenreType));
                        foreach (var tag in jenresAdd) {
                            result.TblMovieJenre
                                .Add (new TblMovieJenre {
                                    JenreId = (long) tag.JenreType
                                });
                        }
                        await EditItem (result);
                    }
                    // 
                    else {
                        var upload = await
                        _uploadServices.SavePostedFileAsync (Input.FormFile, new BITMAPSIZE {
                            W = w,
                                H = h
                        });
                        var movie = new TblMovie ();
                        movie.Title = Input.Title;
                        movie.Type = (byte) _type;
                        movie.Source = Input.Source;
                        movie.FileUrl = upload?.Item1;
                        movie.ThumbnailsUrl = upload?.Item2;
                        movie.KeyWord = Input.KeyWord;
                        movie.ReleaseDate = Input.ReleaseDate?.ToGregorianDateTimeOrDefault ();
                        movie.Interval = Input.Interval;

                        // add tags
                        var tags = new List<TblMovieTags> ();
                        var tagsId = GetIdsByTags (Input.Tags);
                        foreach (var tag in tagsId) {
                            tags.Add (new TblMovieTags {
                                TagsId = tag
                            });
                        }
                        if (tags.Any ()) {
                            movie.TblMovieTags = tags;
                        }

                        // add jenres
                        var jenres = new List<TblMovieJenre> ();
                        foreach (var jenre in Input.JenreTypes) {
                            if (jenre.Selected) {
                                jenres.Add (new TblMovieJenre {
                                    JenreId = (long) jenre.JenreType
                                });
                            }
                        }
                        if (jenres.Any ()) {
                            movie.TblMovieJenre = jenres;
                        }
                        await AddItem (movie);
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
        public async Task<PartialViewResult> OnGetEditAsync (long id) {
            var result = await FindAsync (id);
            var tags = await _dbSet
                .Include (x => x.TblMovieTags)
                .ThenInclude (x => x.TblTags)
                .FirstOrDefaultAsync (x => x.Id == id);

            // tags
            var tagsAsList = new List<string> ();
            foreach (var item in tags.TblMovieTags) {
                tagsAsList.Add ($"{item.TblTags.Id}-{item.TblTags.Title}");
            }

            // jenres
            var jenres = await _dbSet.Include (x => x.TblMovieJenre)
                .ThenInclude (x => x.TblJenre).FirstOrDefaultAsync (x => x.Id == id);

            var jenreAsList = new List<JenreTypeVm> ();
            foreach (JenreType item in Enum.GetValues (typeof (JenreType))) {
                var movieJenre = new JenreTypeVm () { JenreType = item };
                if (jenres.TblMovieJenre.Any (x => x.JenreId == (long) item)) { movieJenre.Selected = true; }
                jenreAsList.Add (movieJenre);
            }

            var model = new InputModel {
                Id = result.Id,
                Title = result.Title,
                Source = result.Source,
                Tags = String.Join (",", tagsAsList),
                KeyWord = result.KeyWord,
                ReleaseDate = result.ReleaseDate?.ToShortPersianDateString ().Replace ("/", "-"),
                Hours = (short) result.Interval.Hours,
                Minutes = (short) result.Interval.Minutes,
                JenreTypes = jenreAsList
            };
            return Partial (_pgAddr.CreateName, model);
        }

        public PartialViewResult OnGetCreate () => base.HandlerCreate<InputModel> ();

        public async Task<IActionResult> OnPostRemove (long id) => await base.HandlerRemove (id);

        private List<int> GetIdsByTags (string tags) {
            var listId = new List<int> ();
            if (!String.IsNullOrEmpty (tags)) {
                var items = tags.Split (',');
                foreach (var item in items) {
                    var tag = item.Split ('-');
                    if (tag.Length > 1) {
                        int id;
                        var tagId = tag[0];
                        if (int.TryParse (tagId, out id)) {
                            listId.Add (id);
                        }
                    }
                }
            }
            return listId;
        }

        public class JenreTypeVm {
            public bool Selected { get; set; }

            public JenreType JenreType { get; set; }
        }
    }
}