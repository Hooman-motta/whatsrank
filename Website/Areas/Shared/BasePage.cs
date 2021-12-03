using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Entities.Base;
using DbLayer.Interfaces;
using HpLayer.Services;
using Website.Helper.Interface;
using Website.Helper.Utils;

namespace Website.Areas.Shared {
    public class RootPage<T> : PageModel where T : BaseEntity, new () {
        public DbSet<T> _dbSet;
        public readonly int _pageSize;
        public readonly PgAddr _pgAddr;
        private string furl = null, turl = null;
        public readonly AppDbContext _context;
        public readonly IUploadServices _uploadServices;
        public RootPage (AppDbContext context, PgAddr pgAddr = null, int pageSize = 10) {
            _pageSize = pageSize;
            _context = context;
            _dbSet = _context.Set<T> ();
            _pgAddr = pgAddr ?? new PgAddr {
                CreateName = "_Create",
                redirectUrl = "./Index"
            };
        }

        public RootPage (AppDbContext context, IUploadServices uploadServices, PgAddr pgAddr = null, int pageSize = 10) {
            _pageSize = pageSize;
            _context = context;
            _dbSet = _context.Set<T> ();
            _uploadServices = uploadServices;
            _pgAddr = pgAddr ?? new PgAddr {
                CreateName = "_Create",
                redirectUrl = "./Index"
            };
        }

        [TempData]
        public string Alert { get; set; }

        [TempData]
        public string EditKey { get; set; }

        #region :: DB ::
        // Add
        protected async Task AddItem (T entity) {
            await _dbSet.AddAsync (entity);
            await _context.SaveChangesAsync ();
        }

        protected async Task AddWithoutCheckState<I> (I input) {
            try {
                // check file
                if (typeof (IFileVm).IsAssignableFrom (typeof (I))) {
                    var item = ((IFileVm) input);
                    var result = await _uploadServices
                        .SavePostedFileAsync (item.FormFile, new BITMAPSIZE {
                            W = item.WidthImage,
                                H = item.HeightImage
                        });
                    item.FileUrl = furl = result?.Item1;
                    item.ThumbnailsUrl = turl = result?.Item2;
                }
                var entity = new T ();
                var entry = await _context.AddAsync (entity);
                entry.CurrentValues.SetValues (input);
                await _context.SaveChangesAsync ();
                Alert = ModelStateType.A200.ModelStateAsText ();
            } catch (DbUpdateException ex) {
                if (!string.IsNullOrEmpty (furl)) {
                    _uploadServices.PhysicalDeleteFile (furl);
                }
                if (!string.IsNullOrEmpty (turl)) {
                    _uploadServices.PhysicalDeleteFile (turl);
                }
                ModelState.AddModelError ("", ex.Message);
                Alert = ModelState.ModelStateAsError ();
            }
        }

        protected async Task<IActionResult> AddWithCheckState<I> (I input) {
            if (ModelState.IsValid) {
                try {
                    if (typeof (IFileVm).IsAssignableFrom (typeof (I))) {
                        var item = ((IFileVm) input);
                        var result = await _uploadServices
                            .SavePostedFileAsync (item.FormFile, new BITMAPSIZE {
                                W = item.WidthImage,
                                    H = item.HeightImage
                            });
                        item.FileUrl = furl = result?.Item1;
                        item.ThumbnailsUrl = turl = result?.Item2;
                    }
                    var entity = new T ();
                    var entry = await _context.AddAsync (entity);
                    entry.CurrentValues.SetValues (input);
                    await _context.SaveChangesAsync ();
                    Alert = ModelStateType.A200.ModelStateAsText ();
                } catch (DbUpdateException ex) {
                    if (!string.IsNullOrEmpty (furl)) {
                        _uploadServices.PhysicalDeleteFile (furl);
                    }
                    if (!string.IsNullOrEmpty (turl)) {
                        _uploadServices.PhysicalDeleteFile (turl);
                    }
                    ModelState.AddModelError ("", ex.Message);
                    Alert = ModelState.ModelStateAsError ();
                }
            } else {
                ModelState.AddModelError ("", ConstValues.ErRequest);
                Alert = ModelState.ModelStateAsError ();
            }
            return RedirectToPage (_pgAddr.redirectUrl);
        }

        // Edit
        public async Task EditItem (T entity) {
            // if (typeof (ITrackEntity).IsAssignableFrom (typeof (T))) {
            //     ((ITrackEntity) entity).UpdatedDate = DateTime.UtcNow;
            // }
            _dbSet.Update (entity);
            await _context.SaveChangesAsync ();
        }

        // Remove
        protected async Task RemoveItem (object id) {
            var entity = await _dbSet.FindAsync (id);
            await RemoveItem (entity);
        }

        protected async Task RemoveItem (IEnumerable<T> entities) {
            foreach (var item in entities) {
                await RemoveItem (item);
            }
        }

        protected async Task RemoveItem (T entity) {
            if (typeof (IFileEntity).IsAssignableFrom (typeof (T))) {
                var item = ((IFileEntity) entity);
                var fileUrl = item.FileUrl;
                var thumbnailsUrl = item.ThumbnailsUrl;
                _dbSet.Remove (entity);
                await _context.SaveChangesAsync ();
                if (!string.IsNullOrEmpty (fileUrl)) {
                    _uploadServices.PhysicalDeleteFile (fileUrl);
                }
                if (!string.IsNullOrEmpty (thumbnailsUrl)) {
                    _uploadServices.PhysicalDeleteFile (thumbnailsUrl);
                }
                return;
            }
            _dbSet.Remove (entity);
            await _context.SaveChangesAsync ();
        }

        // Find
        protected async Task<T> FindAsync (long id) =>
            await _dbSet.FindAsync (id);

        protected async Task<T> FindAsNotTrackAsync (long id) =>
            await _dbSet.AsNoTracking ().FirstOrDefaultAsync (x => x.Id == id);

        protected async Task<T> FirstAsync () =>
            await _dbSet.FirstOrDefaultAsync ();

        protected async Task<T> FirstAsync (Expression<Func<T, bool>> predicate) =>
            await _dbSet.FirstOrDefaultAsync (predicate);
        #endregion

        #region :: Handler ::
        protected async Task<IActionResult> HandlerRemove (object pk) {
            try {
                await RemoveItem (pk);
                Alert = ModelStateType.A200.ModelStateAsText ();
            } catch (DbUpdateException ex) {
                ModelState.AddModelError ("", ex.Message);
                Alert = ModelState.ModelStateAsError ();
            }
            return RedirectToPage (_pgAddr.redirectUrl);
        }

        protected PartialViewResult HandlerCreate<I> () where I : new () => Partial (_pgAddr.CreateName, new I ());
        #endregion
    }
    public class PgAddr {
        public string CreateName { get; set; }
        public string redirectUrl { get; set; }
    }

    #region :: Comment ::
    // public IQueryable<T> List (Expression<Func<T, bool>> expression) {
    //     return _dbSet.Where (expression);
    // }

    // public IQueryable<T> ByInclues (params Expression<Func<T, object>>[] includes) {
    //     var result = _dbSet.AsQueryable ();
    //     foreach (var includeExpression in includes)
    //         result = result.Include (includeExpression);
    //     return result;
    // }

    // public virtual T Fetch () {
    //     throw new NotImplementedException ();
    // }

    // public async Task<Tuple<string, string>> UploadFile (IFormFile formFile, UploadSize uploadSize) =>
    //     await _uploadServices.SavePostedFileAsync (formFile, uploadSize);

    // public async Task<T> LatestAsync () =>
    //     await _dbSet.OrderByDescending (x => x.Id).FirstOrDefaultAsync ();

    // Paginate
    // public async Task<List<T>> PaginatedAsync (int page = 1) {
    //     var result = await _dbSet
    //         .OrderBy (x => x.Id)
    //         .Skip ((page - 1) * _pageSize)
    //         .Take (_pageSize).ToListAsync ();
    //     await SetPageCount ();
    //     return result;
    // }

    // public async Task<List<T>> PaginatedDescAsync (int page = 1) {
    //     var result = await _dbSet
    //         .OrderByDescending (x => x.Id)
    //         .Skip ((page - 1) * _pageSize)
    //         .Take (_pageSize).ToListAsync ();
    //     await SetPageCount ();
    //     return result;
    // }

    // public async Task<List<T>> PaginatedDescAsync (IQueryable<T> queryable, int page = 1) {
    //     var result = await queryable
    //         .OrderByDescending (x => x.Id)
    //         .Skip ((page - 1) * _pageSize)
    //         .Take (_pageSize).ToListAsync ();
    //     await SetPageCount ();
    //     return result;
    // }

    //    public async Task<List<T>> PaginatedDescAsync (Expression<Func<T, bool>> where, int page = 1) {
    //             var result = await _dbSet
    //                 .Where (where)
    //                 .OrderByDescending (x => x.Id)
    //                 .Skip ((page - 1) * _pageSize)
    //                 .Take (_pageSize).ToListAsync ();
    //             return result;
    //         }

    // private async Task SetPageCount () {
    //     var count = await _dbSet.CountAsync ();
    //     PageCount = (int) Math.Ceiling (((double) count / _pageSize));
    // }
    #endregion
}