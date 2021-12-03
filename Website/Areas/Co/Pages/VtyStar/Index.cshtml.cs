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
using DbLayer.Enums;
using HpLayer.Attributes;
using HpLayer.Services;
using Website.Areas.Shared;
using Website.Helper.Interface;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Areas.Co.Pages.VtyStar {
    public class IndexModel : RootPage<TblVtyStarsWar> {

        public IndexModel (AppDbContext context, IUploadServices uploadServices) : base (context, uploadServices) { }

        public class InputModel : IFileVm {
            public long? Id { get; set; }

            [Display (Name = "عنوان : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Title { get; set; }

            [Display (Name = "سوال : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Question { get; set; }

            [Display (Name = "آدرس ویدئو : ")]
            public string VideoUrl { get; set; }

            [StringLength (500)]
            [Display (Name = "کلمه کلیدی : ")]
            public string KeyWord { get; set; }

            [Display (Name = "برچسب : ")]
            public string Tags { get; set; }

            public string Source { get; set; }

            [Display (Name = "نوع : ")]
            public VtyStarsWarType Type { get; set; }

            [Display (Name = "باموضوع : ")]
            public VtyStarsWarSubject Subject { get; set; }

            // file
            [Display (Name = "تصویر : ")]
            [AllowedExtensions (new string[] { ".jpg", ".png", ".jpeg" })]
            [AttrRequestSizeLimit (ConstValues.UPLOAD_SIZE_IMAGE_IN_MB)]
            public IFormFile FormFile { get; set; }

            public string FileUrl { get; set; }

            public string ThumbnailsUrl { get; set; }

            public int WidthImage { get; set; } = 290;

            public int HeightImage { get; set; } = 165;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel : InputModel {
            public string TypeTitle { get; set; }
            public string SubjectTitle { get; set; }

            public string PersianCreatedDate { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync ([FromQuery] FilterQs vm) {
            var entity = _dbSet.AsNoTracking ();
            if (!string.IsNullOrEmpty (vm.Filter)) {
                entity = entity.Where (x => x.Title.Contains (vm.Filter));
            }
            List = await PaginatedList<ListModel>.CreateAsync (
                entity.Select (x => new ListModel {
                    Id = x.Id,
                        Title = x.Title,
                        TypeTitle = x.TypeTitle,
                        SubjectTitle = x.SubjectTitle,
                        Question = x.Question, VideoUrl = x.VideoUrl,
                        FileUrl = x.FileUrl,
                        KeyWord = x.KeyWord,
                        Source = x.Source,
                        PersianCreatedDate = x.PersianCreatedDate
                }), vm.P, _pageSize
            );
        }

        public async Task<IActionResult> OnPostAsync () {
            if (ModelState.IsValid) {
                try {
                    if (Input.Id.HasValue) {
                        var tagsId = GetIdsByTags (Input.Tags);
                        var result = await _dbSet.Include (x => x.TblVtyStarsWarTags)
                            .FirstOrDefaultAsync (x => x.Id == Input.Id);
                        result.Type = Input.Type;
                        result.Title = Input.Title;
                        result.Question = Input.Question;
                        result.VideoUrl = Input.VideoUrl;
                        if (Input.FormFile != null) {
                            _uploadServices.PhysicalDeleteFile (result.FileUrl);
                            _uploadServices.PhysicalDeleteFile (result.ThumbnailsUrl);
                            var uploaded = await _uploadServices
                                .SavePostedFileAsync (Input.FormFile, new BITMAPSIZE {
                                    W = Input.WidthImage,
                                        H = Input.HeightImage
                                });
                            result.FileUrl = uploaded?.Item1;
                            result.ThumbnailsUrl = uploaded?.Item2;
                        }
                        result.Source = Input.Source;
                        result.KeyWord = Input.KeyWord;
                        result.Subject = Input.Subject;
                        // remove
                        var tagsShouldBeRemove = result.TblVtyStarsWarTags
                            .Where (x => !tagsId.Any (y => y == x.TagsId));
                        foreach (var tag in tagsShouldBeRemove) {
                            result.TblVtyStarsWarTags.Remove (tag);
                        }
                        // add
                        var tagsShouldBeAdd = tagsId
                            .Where (x => !result.TblVtyStarsWarTags.Any (y => y.TagsId == x));
                        foreach (var tag in tagsShouldBeAdd) {
                            result.TblVtyStarsWarTags.Add (new TblVtyStarsWarTags { TagsId = tag });
                        }
                        await EditItem (result);
                    } else {
                        var vtyStarsWar = new TblVtyStarsWar {
                            Title = Input.Title,
                            Question = Input.Question,
                            VideoUrl = Input.VideoUrl,
                            Type = Input.Type,
                            KeyWord = Input.KeyWord,
                            Source = Input.Source,
                            Subject = Input.Subject,
                        };
                        if (Input.FormFile != null) {
                            var uploadResult = await _uploadServices
                                .SavePostedFileAsync (Input.FormFile, new BITMAPSIZE {
                                    W = Input.WidthImage,
                                        H = Input.HeightImage
                                });
                            vtyStarsWar.FileUrl = uploadResult?.Item1;
                            vtyStarsWar.ThumbnailsUrl = uploadResult?.Item2;
                        }
                        var tags = new List<TblVtyStarsWarTags> ();
                        var tagsId = GetIdsByTags (Input.Tags);
                        foreach (var tag in tagsId) {
                            tags.Add (new TblVtyStarsWarTags {
                                TagsId = tag
                            });
                        }
                        if (tags.Any ()) {
                            vtyStarsWar.TblVtyStarsWarTags = tags;
                        }

                        await AddItem (vtyStarsWar);
                    }
                    Alert = ModelStateType.A200.ModelStateAsText ();
                } catch (Exception ex) {
                    ModelState.AddModelError ("", ex.Message);
                    Alert = ModelState.ModelStateAsError ();
                }
            }
            return RedirectToPage ("./Index");
        }

        public async Task<PartialViewResult> OnGetEditAsync (long id) {
            var result = await FindAsync (id);
            var tagsList = await _dbSet.Include (x => x.TblVtyStarsWarTags)
                .ThenInclude (x => x.TblTags).FirstOrDefaultAsync (x => x.Id == id);
            var tagsAsList = new List<string> ();
            foreach (var item in tagsList.TblVtyStarsWarTags) {
                tagsAsList.Add ($"{item.TblTags.Id}-{item.TblTags.Title}");
            }
            var model = new InputModel {
                Id = result.Id,
                Type = result.Type,
                Subject = result.Subject,
                Title = result.Title,
                Question = result.Question,
                KeyWord = result.KeyWord,
                VideoUrl = result.VideoUrl,
                Tags = String.Join (",", tagsAsList),
                Source = result.Source
            };
            return Partial ("_Create", model);
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
    }
}