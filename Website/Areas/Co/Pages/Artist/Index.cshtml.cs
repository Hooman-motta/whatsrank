using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// 
using CldLayer.Persian;
using DbLayer.Context;
using DbLayer.Entities;
using HpLayer.Attributes;
using HpLayer.Services;
using Website.Areas.Shared;
using Website.Helper.Interface;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Areas.Co.Pages.Artist {
    public class IndexModel : RootPage<TblArtist> {
        public IndexModel (AppDbContext context, IUploadServices uploadServices) : base (context, uploadServices) { }

        public class InputModel : IFileVm {
            [Display (Name = "هنرمند : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string FullName { get; set; }

            [Display (Name = "متولد : ")]
            public string _BirthDate { get; set; }

            public DateTime? BirthDate => _BirthDate?.ToGregorianDateTime ();

            // file
            [Display (Name = "تصویر : ")]
            [AllowedExtensions (new string[] { ".jpg", ".png", ".jpeg" })]
            [AttrRequestSizeLimit (ConstValues.UPLOAD_SIZE_IMAGE_IN_MB)]
            public IFormFile FormFile { get; set; }
            public string FileUrl { get; set; }
            public string ThumbnailsUrl { get; set; }
            public int WidthImage { get; set; } = 125;
            public int HeightImage { get; set; } = 110;

            // 
            [Display (Name = "خلاصه : ")]
            public string Bio { get; set; }

            [Display (Name = "کلمه کلیدی : ")]
            public string KeyWord { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel : InputModel {
            public long Id { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync ([FromQuery] FilterQs vm) {
            var entity = _dbSet.AsNoTracking ();
            if (!string.IsNullOrEmpty (vm.Filter)) {
                entity = _dbSet.Where (x => x.FullName.Contains (vm.Filter));
            }
            List = await PaginatedList<ListModel>.CreateAsync (
                entity.Select (x => new ListModel {
                    Id = x.Id, FullName = x.FullName,
                        FileUrl = x.FileUrl, Bio = x.Bio, KeyWord = x.KeyWord,
                        _BirthDate = x.BirthDate.ToLongPersianDateString () ?? "---"
                }), vm.P, _pageSize
            );
        }

        public async Task<IActionResult> OnPostAsync () {
            if (ModelState.IsValid) {
                try {
                    var alreadyArtist = await _context.TblArtist
                        .AnyAsync (x => x.FullName == Input.FullName);
                    if (EditKey != null) {
                        long key = long.Parse (EditKey);
                        return await ModifyItem (key, alreadyArtist);
                    }
                    if (alreadyArtist) {
                        throw new Exception ($"هنرمند با اسم '{Input.FullName}' پیشتر ثبت شده است.");
                    }
                    await base.AddWithoutCheckState<InputModel> (Input);
                    Alert = ModelStateType.A200.ModelStateAsText ();
                } catch (Exception ex) {
                    ModelState.AddModelError ("", ex.Message);
                    Alert = ModelState.ModelStateAsError ();
                }
            }
            return RedirectToPage ("./Index");
        }

        // handler
        public PartialViewResult OnGetCreate () => base.HandlerCreate<InputModel> ();

        public async Task<PartialViewResult> OnGetEditAsync (long id) {
            var result = await FindAsync (id);
            EditKey = result.Id.ToString ();
            return Partial ("_Create", new InputModel {
                FullName = result.FullName,
                    Bio = result.Bio,
                    KeyWord = result.KeyWord,
                    _BirthDate = result.BirthDate?.ToShortPersianDateString ().Replace ("/", "-"),
            });
        }

        public async Task<IActionResult> OnGetCinemaRoleAsSelectAsync (int id) {
            try {
                var artist = await _dbSet
                    .Include (x => x.TblArtistCinemaRole)
                    .ThenInclude (x => x.TblCinemaRole)
                    .FirstOrDefaultAsync (x => x.Id == id);
                var cinemaRoleAsSelect = artist.TblArtistCinemaRole
                    .Select (x => new SelectListItem {
                        Value = x.CinemaRoleId.ToString (),
                            Text = x.TblCinemaRole.Title
                    }).ToList ();
                cinemaRoleAsSelect.Insert (0, new SelectListItem () {
                    Text = "انتخاب کنید",
                        Value = "0"
                });
                return new OkObjectResult (cinemaRoleAsSelect);
            } catch {
                return BadRequest (ConstValues.ErOnFetchingData);
            }
        }

        private async Task<IActionResult> ModifyItem (long pk, bool alreadyArtist) {
            try {
                long key = long.Parse (EditKey);
                var item = await FindAsync (key);
                if (item.FullName != Input.FullName && alreadyArtist) {
                    throw new Exception ($"هنرمند با اسم {Input.FullName} پیشتر ثبت شده است");
                }
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
                item.BirthDate = Input._BirthDate?.ToGregorianDateTime ();
                if (await TryUpdateModelAsync<TblArtist> (item, "",
                        x => x.FullName,
                        x => x.Bio,
                        x => x.KeyWord
                    )) {
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