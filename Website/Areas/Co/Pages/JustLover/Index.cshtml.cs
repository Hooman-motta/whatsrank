using System;
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

namespace Website.Areas.Co.Pages.JustLover {
    public class IndexModel : RootPage<TblJustLover> {
        public IndexModel (AppDbContext context, IUploadServices uploadServices) : base (context, uploadServices) { }

        public class InputModel : IFileVm {
            [Display (Name = "عنوان : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Title { get; set; }

            [Display (Name = "سوال : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Question { get; set; }

            [Display (Name = "گزینه اول : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Option1 { get; set; }

            [Display (Name = "گزینه دوم : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Option2 { get; set; }

            [Display (Name = "گزینه سوم : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Option3 { get; set; }

            [Display (Name = "گزینه چهارم : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Option4 { get; set; }

            [Display (Name = "گزینه درست : ")]
            [Required (ErrorMessage = ConstValues.RqError), Range (1, 4, ErrorMessage = "بین 1 تا 4 مجاز می باشد")]
            public byte AnswerNO { get; set; }

            // file
            [Display (Name = "فایل : ")]
            [AllowedExtensions (new string[] { ".jpg", ".png", ".jpeg", ".mp3", ".ogg" })]
            [AttrRequestSizeLimit (ConstValues.UPLOAD_SIZE_IMAGE_IN_MB)]
            public IFormFile FormFile { get; set; }

            public string FileUrl { get; set; }
            public string ThumbnailsUrl { get; set; }
            public int WidthImage { get; set; } = 290;
            public int HeightImage { get; set; } = 165;
            public JustLoverType Type => FormFile == null ? JustLoverType.Fram :
                FormFile.IsBITMAP () ? JustLoverType.Fram : JustLoverType.Music;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel : InputModel {
            public long Id { get; set; }
            public bool IsExpired { get; set; }
            public JustLoverType ViewType { set; get; }
            public string PersianCreatedDate { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync ([FromQuery] FilterQs vm) {
            var entity = _dbSet.AsNoTracking ();
            if (!string.IsNullOrEmpty (vm.Filter)) {
                entity = _dbSet.Where (x => x.Title.Contains (vm.Filter));
            }
            List = await PaginatedList<ListModel>.CreateAsync (
                entity.OrderByDescending (x => x.Id)
                .Select (x => new ListModel {
                    Id = x.Id,
                        Title = x.Title,
                        ViewType = x.Type,
                        Question = x.Question,
                        PersianCreatedDate = x.PersianCreatedDate,
                        Option1 = x.Option1,
                        Option2 = x.Option2,
                        Option3 = x.Option3,
                        Option4 = x.Option4,
                        FileUrl = x.FileUrl,
                        IsExpired = x.IsExpired,
                        AnswerNO = x.AnswerNO
                }), vm.P, _pageSize
            );
        }

        public async Task<IActionResult> OnPostAsync () {
            if (ModelState.IsValid) {
                if (EditKey != null) {
                    long key = long.Parse (EditKey);
                    return await ModifyItem (key);
                }
                await base.AddWithoutCheckState<InputModel> (Input);
            }
            return RedirectToPage ("./Index");
        }

        // handler
        public async Task<PartialViewResult> OnGetEditAsync (long id) {
            var result = await FindAsync (id);
            EditKey = result.Id.ToString ();
            return Partial ("_Create", new InputModel {
                Title = result.Title,
                    Question = result.Question,
                    Option1 = result.Option1,
                    Option2 = result.Option2,
                    Option3 = result.Option3,
                    Option4 = result.Option4,
                    AnswerNO = result.AnswerNO
            });
        }

        public PartialViewResult OnGetCreate () => base.HandlerCreate<InputModel> ();

        public async Task<IActionResult> OnPostRemove (long id) => await base.HandlerRemove (id);

        public async Task<IActionResult> OnGetExpireAsync (long id) {
            try {
                var result = await FindAsync (id);
                result.IsExpired = !result.IsExpired;
                await EditItem (result);
                return new OkObjectResult ("Your request has been succeed.");
            } catch {
                return BadRequest (ConstValues.ErOnFetchingData);
            }
        }

        private async Task<IActionResult> ModifyItem (long pk) {
            try {
                var item = await FindAsync (pk);
                if (Input.FormFile != null) {
                    // remove old file
                    _uploadServices.PhysicalDeleteFile (item.FileUrl);
                    _uploadServices.PhysicalDeleteFile (item.ThumbnailsUrl);
                    // upload new file
                    var uploaded = await _uploadServices
                        .SavePostedFileAsync (Input.FormFile, new BITMAPSIZE {
                            W = Input.WidthImage,
                                H = Input.HeightImage
                        });
                    item.FileUrl = uploaded?.Item1;
                    item.ThumbnailsUrl = uploaded?.Item2;
                }
                if (await TryUpdateModelAsync<TblJustLover> (item, "",
                        x => x.Title,
                        x => x.Question,
                        x => x.Option1,
                        x => x.Option2,
                        x => x.Option3,
                        x => x.Option4,
                        x => x.AnswerNO)) {
                    await _context.SaveChangesAsync ();
                }
                Alert = ModelStateType.A200.ModelStateAsText ();
            } catch (DbUpdateException ex) {
                ModelState.AddModelError ("", ex.Message);
                Alert = ModelState.ModelStateAsError ();
            }
            return RedirectToPage ("./Index");
        }
    }
}