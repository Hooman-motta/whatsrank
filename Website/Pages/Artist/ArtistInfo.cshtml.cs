using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using CldLayer.Persian;
using DbLayer.Context;
using Website.Helper.Utils;
using Website.Helper.Vmodel;
using Website.Service.SrcIdentity.Configure;

namespace Website.Pages.Artist {
    public class ArtistInfoModel : PageModel {
        public readonly AppDbContext _context;
        public ArtistInfoModel (AppDbContext context) {
            _context = context;
        }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }

        // Artist
        public class ViewResultVm {
            public long ArtistId { get; set; }
            public string FriendlyUrl { get; set; }
            public string FullName { get; set; }
            public string BirthDate { get; set; }
            public string KeyWord { get; set; }
            public string Bio { get; set; }
            public string CinemaRoles { get; set; }
            public List<ArtistMovieVm> Movie { get; set; }
            public List<SimilarArtistVm> SimilarArtist { get; set; }
        }

        public VoteHelperVm Vote { get; set; }

        public ViewResultVm ViewResult { get; set; }

        public async Task OnGetAsync () {
            string userId = null;
            if (User.Identity.IsAuthenticated) {
                userId = User.Identity.GetUserId<string> ();
            }

            var list = new ViewResultVm ();
            var artist = await _context.TblArtist
                .Include (x => x.TblArtistCinemaRole.Where (x => x.ArtistId == Id))
                .ThenInclude (x => x.TblCinemaRole.TblArtistCinemaRole.Where (x => x.ArtistId == Id))
                .FirstOrDefaultAsync (x => x.Id == Id);
            list.Bio = artist.Bio;
            list.ArtistId = Id;
            list.KeyWord = artist.KeyWord;
            list.FriendlyUrl = artist.FileUrl.ToFriendlyImage (DefaultImageType.DEF_AVATAR);
            list.FullName = artist.FullName;
            list.BirthDate = artist.BirthDate?.ToLongPersianDateString ();
            list.CinemaRoles = String.Join (" , ", artist.TblArtistCinemaRole.Select (x => x.TblCinemaRole.TypeTitle));

            // artist movies
            var movie = await _context.TblArtist
                .SelectMany (x => x.TblArtistMovieRole)
                .Where (x => x.ArtistId == Id)
                .Include (x => x.TblMovie).Include (x => x.TblCinemaRole)
                .Include (x => x.TblArtistVote.Where (y => y.ArtistId == Id))
                .Select (x => new ArtistMovieVm {
                    AMRId = x.Id,
                        MovieId = x.MovieId,
                        MovieTitle = x.TblMovie.Title,
                        RoleInMovie = x.TblCinemaRole.Title,
                        FriendlyUrl = x.TblMovie.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF_MOVIIE),
                        VoteCount = x.TblArtistVote.Count (),
                        VoteAverage = x.TblArtistVote.Any () ? x.TblArtistVote.Average (x => x.Mark) : 0,
                        UserMark = x.TblArtistVote.Any (x => x.UserId == userId) ? x.TblArtistVote.FirstOrDefault (x => x.UserId == userId).Mark : null
                }).OrderBy (g => Guid.NewGuid ())
                .Take (20).AsNoTracking ().ToListAsync ();
            list.Movie = movie;

            int take = 10;
            var similarTypes = artist.TblArtistCinemaRole.Select (x => x.TblCinemaRole.Id).ToArray ();
            var groupedArtistCinemaRole = _context.TblArtist.SelectMany (x => x.TblArtistCinemaRole)
                .Where (x => similarTypes.Contains (x.CinemaRoleId) && x.ArtistId != Id).AsEnumerable ()
                .GroupBy (x => new { x.ArtistId, x.CinemaRoleId }).OrderBy (g => Guid.NewGuid ()).Take (take).ToList ();
            list.SimilarArtist = _context.TblArtist
                .AsEnumerable ().Where (x => groupedArtistCinemaRole.Any (y => y.Key.ArtistId == x.Id))
                .Select (x => new SimilarArtistVm {
                    ArtistId = x.Id,
                        FullName = x.FullName,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF_AVATAR),
                }).ToList ();

            var vote = await _context
                .TblArtistVote.Where (x => x.ArtistId == Id)
                .GroupBy (x => x.ArtistId).Select (x => new VoteHelperVm {
                    VoteCount = x.Count (), VoteAverage = x.Average (y => y.Mark)
                }).FirstOrDefaultAsync ();

            ViewResult = list;
            Vote = vote ?? new VoteHelperVm ();
        }

        // Movie
        public class ArtistMovieVm : VoteHelperVm {
            public long AMRId { get; set; }

            public long MovieId { get; set; }

            public string MovieTitle { get; set; }

            public string RoleInMovie { get; set; }

            public byte? UserMark { get; set; } = null;

            public string FriendlyUrl { get; set; }
        }

        // Similar
        public class SimilarArtistVm {
            public long ArtistId { get; set; }

            public string FullName { get; set; }

            public string FriendlyUrl { get; set; }
        }
    }
}