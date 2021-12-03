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
using DbLayer.Entities;
using DbLayer.Enums;
using HpLayer.Extensions;
using HpLayer.Helper;
using Website.Helper.Utils;
using Website.Helper.Vmodel;
using Website.Service.SrcIdentity.Configure;

namespace Website.Pages.Movie {
    public class MovieInfoModel : PageModel {
        private readonly AppDbContext _context;
        private const string voteError = "درخواست رای شما با خطا مواجعه شد.";

        public MovieInfoModel (AppDbContext context) { _context = context; }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }

        public class ListModel : VoteHelperVm {
            public long MovieId { get; set; }
            public string MovieTitle { get; set; }
            public string ReleaseDate { get; set; }
            public string Time { get; set; }
            public string FriendlyUrl { get; set; }
            public MovieType MovieType { get; set; }
            public string Source { get; set; }
            public string KeyWord { get; set; }
            public string Tags { get; set; }
            public string Jenre { get; set; }
            public long[] Jenres { get; set; }
            public byte? UserMark { get; set; }
            public List<ArtistsVm> Artists { get; set; }
            public List<SerialInfoVm> SerialInfo { get; set; }
            public List<SimilarMoviesVm> SimilarMovies { get; set; }
        }

        public ListModel List { get; set; }

        public async Task OnGetAsync () {
            string userId = null;
            if (User.Identity.IsAuthenticated) {
                userId = User.Identity.GetUserId<string> ();
            }
            var result = await _context.TblMovie
                .Include (x => x.TblMovieVote.Where (y => y.MovieId == Id))
                .Include (x => x.TblMovieTags.Where (y => y.MovieId == Id))
                .Include (x => x.TblMovieJenre.Where (y => y.MovieId == Id))
                .Select (x => new ListModel {
                    MovieId = x.Id,
                        MovieTitle = x.Title,
                        ReleaseDate = x.ReleaseDate.ToLongPersianDateString (),
                        Time = $"{x.Interval.Hours.ToString()} ساعت و {x.Interval.Minutes.ToString()} دقیقه",
                        MovieType = (MovieType) x.Type,
                        VoteCount = x.TblMovieVote.Count (),
                        VoteAverage = x.TblMovieVote.Any () ? x.TblMovieVote.Average (x => x.Mark) : 0,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF_MOVIIE),
                        KeyWord = x.KeyWord, Source = x.Source,
                        Tags = x.TblMovieTags.Any () ? String.Join ("-", (x.TblMovieTags.Select (x => x.TblTags.Title))) : null,
                        Jenre = x.TblMovieJenre.Any () ? String.Join (" , ", (x.TblMovieJenre.Select (x => x.TblJenre.Title))) : null,
                        Jenres = x.TblMovieJenre.Any () ? x.TblMovieJenre.Select (x => x.TblJenre.Id).ToArray () : new long[0],
                        UserMark = x.TblMovieVote.Any (x => x.UserId == userId) ?
                        x.TblMovieVote.FirstOrDefault (x => x.UserId == userId).Mark : null,
                }).AsNoTracking ().FirstOrDefaultAsync (x => x.MovieId == Id);

            // artists
            result.Artists = await FetchArtistInfoAsync (userId);

            // serial info
            if (result != null) {
                if (result.MovieType == MovieType.Serial) {
                    result.SerialInfo = await FetchSerialInfoAsync (userId);
                }
            }

            // similar movies    
            result.SimilarMovies = await FetchSimilarMovieAsync (result.Jenres);
            List = result;
        }

        public async Task<IActionResult> OnPostSetVoteAsync (byte markValue) {
            try {
                if (markValue < 0 && markValue > 10) {
                    throw new Exception (voteError);
                }

                var userId = User.Identity.GetUserId<string> ();
                var movieVote = await _context.TblMovieVote
                    .FirstOrDefaultAsync (x => x.MovieId == Id && x.UserId == userId);

                if (movieVote != null) {
                    movieVote.Mark = markValue;
                    _context.TblMovieVote.Update (movieVote);
                    await _context.SaveChangesAsync ();
                } else {
                    await _context.TblMovieVote
                        .AddAsync (new TblMovieVote {
                            UserId = userId,
                                Mark = markValue,
                                MovieId = Id
                        });
                    await _context.SaveChangesAsync ();
                }
                var voteResponse = new VoteResponseVm {
                    MarkValue = markValue
                };
                voteResponse.Vote = await _context
                    .TblMovieVote.Where (x => x.MovieId == Id)
                    .GroupBy (x => x.MovieId).Select (x => new VoteHelperVm {
                        VoteCount = x.Count (), VoteAverage = x.Average (y => y.Mark),
                    }).FirstOrDefaultAsync ();

                return new OkObjectResult (ApiResult.Succeeded (voteResponse));
            } catch (Exception ex) {
                ModelState.AddModelError ("", ex.Message);
                var errors = ModelState.ModelStateErrorAsApiResult ();
                return new BadRequestObjectResult (ApiResult.Failed (errors));
            }
        }

        public async Task<IActionResult> OnPostArtistVoteAsync (byte markValue, long itemId) {
            try {
                if (markValue < 0 && markValue > 10) {
                    throw new Exception (voteError);
                }

                var userId = User.Identity.GetUserId<string> ();
                var artistVote = await _context.TblArtistVote
                    .FirstOrDefaultAsync (x => x.ArtistMovieRoleId == itemId && x.UserId == userId);

                if (artistVote != null) {
                    artistVote.Mark = markValue;
                    _context.TblArtistVote.Update (artistVote);
                    await _context.SaveChangesAsync ();
                } else {
                    var movieRole = await _context.TblArtistMovieRole
                        .FirstOrDefaultAsync (x => x.Id == itemId);
                    await _context.TblArtistVote
                        .AddAsync (new TblArtistVote {
                            UserId = userId,
                                Mark = markValue,
                                ArtistId = movieRole.ArtistId,
                                ArtistMovieRoleId = itemId,
                        });
                    await _context.SaveChangesAsync ();
                }

                var voteResponse = new VoteResponseVm {
                    MarkValue = markValue
                };
                voteResponse.Helper = $"amr-{itemId.ToString ()}";
                voteResponse.Vote = await _context.TblArtistVote
                    .Where (x => x.ArtistMovieRoleId == itemId)
                    .GroupBy (x => x.ArtistMovieRoleId)
                    .Select (x => new VoteHelperVm {
                        VoteCount = x.Count (),
                            VoteAverage = x.Average (y => y.Mark),
                    }).FirstOrDefaultAsync ();
                return new OkObjectResult (ApiResult.Succeeded (voteResponse));
            } catch (Exception ex) {
                ModelState.AddModelError ("", ex.Message);
                var errors = ModelState.ModelStateErrorAsApiResult ();
                return new BadRequestObjectResult (ApiResult.Failed (errors));
            }
        }

        public async Task<IActionResult> OnPostSerialVoteAsync (byte markValue, long itemId) {
            try {
                if (markValue < 0 && markValue > 10) {
                    throw new Exception (voteError);
                }
                var userId = User.Identity.GetUserId<string> ();
                var serialVote = await _context.TblSerialVote
                    .FirstOrDefaultAsync (x => x.SerialInfoId == itemId && x.UserId == userId);
                if (serialVote != null) {
                    serialVote.Mark = markValue;
                    _context.TblSerialVote.Update (serialVote);
                    await _context.SaveChangesAsync ();
                } else {
                    await _context.TblSerialVote
                        .AddAsync (new TblSerialVote {
                            UserId = userId,
                                Mark = markValue,
                                SerialInfoId = itemId
                        });
                    await _context.SaveChangesAsync ();
                }

                var voteResponse = new VoteResponseVm {
                    MarkValue = markValue,
                    Helper = $"sv-{itemId.ToString ()}",
                };
                voteResponse.Vote = await _context.TblSerialVote
                    .Where (x => x.SerialInfoId == itemId)
                    .GroupBy (x => x.SerialInfoId)
                    .Select (x => new VoteHelperVm {
                        VoteCount = x.Count (),
                            VoteAverage = x.Average (y => y.Mark),
                    }).FirstOrDefaultAsync ();
                return new OkObjectResult (ApiResult.Succeeded (voteResponse));
            } catch (Exception ex) {
                ModelState.AddModelError ("", ex.Message);
                var errors = ModelState.ModelStateErrorAsApiResult ();
                return new BadRequestObjectResult (ApiResult.Failed (errors));
            }
        }

        // private
        private async Task<List<ArtistsVm>> FetchArtistInfoAsync (string userId) {
            var result = await _context
                .TblArtistMovieRole.Include (x => x.TblArtist)
                .Include (x => x.TblCinemaRole).Include (x => x.TblArtistVote)
                .Where (x => x.MovieId == Id).AsNoTracking ()
                .Select (x => new ArtistsVm {
                    AMRId = x.Id,
                        ArtistId = x.ArtistId,
                        FullName = x.TblArtist.FullName,
                        FriendlyUrl = x.TblArtist.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF_AVATAR),
                        VoteCount = x.TblArtistVote.Count (),
                        VoteAverage = x.TblArtistVote.Any () ? x.TblArtistVote.Average (x => x.Mark) : 0,
                        ArtistRole = x.TblCinemaRole.CinemaRoleType,
                        HelperArtistSort = x.TblCinemaRole.Type,
                        UserMark = x.TblArtistVote.Any (x => x.UserId == userId) ?
                        x.TblArtistVote.FirstOrDefault (x => x.UserId == userId).Mark : null,
                }).OrderBy (x => x.HelperArtistSort).ToListAsync ();
            return result;
        }

        private async Task<List<SerialInfoVm>> FetchSerialInfoAsync (string userId) {
            var serialInfo = new List<SerialInfoVm> ();
            var result = await _context.TblSerialInfo
                .Where (x => x.MovieId == Id && x.ParentId == null)
                .Include (x => x.Children).ThenInclude (x => x.TblSerialVote)
                .OrderBy (x => x.Parent.Number)
                .ToListAsync ();
            foreach (var item in result) {
                var seasons = new SerialInfoVm ();
                seasons.SeasonId = item.Id;
                seasons.Season = item.NumberTitle;
                var children = new List<ChapterVm> ();
                foreach (var child in item.Children) {
                    var chapter = new ChapterVm {
                        ChapterId = child.Id,
                        Chapter = child.NumberTitle,
                        FriendlyUrl = child.ThumbnailsUrl,
                        Vote = (decimal) child.TblSerialVote.Sum (x => x.Mark),
                        UserMark = child.TblSerialVote.Any (x => x.UserId == userId) ?
                        child.TblSerialVote.First (x => x.UserId == userId).Mark : null
                    };
                    children.Add (chapter);
                }
                seasons.Chapters = children;
                serialInfo.Add (seasons);
            }
            return serialInfo;
        }

        private async Task<List<SimilarMoviesVm>> FetchSimilarMovieAsync (long[] jenres) {
            var similarMovies = await _context.TblMovie
                .Include (x => x.TblMovieJenre.Where (y => jenres.Any (j => j == y.JenreId)))
                .Where (x => x.Id != Id && x.TblMovieJenre.Any (y => jenres.Any (j => j == y.JenreId)))
                .OrderBy (g => Guid.NewGuid ()).Take (10).AsNoTracking ().Select (x => new SimilarMoviesVm {
                    Id = x.Id,
                        MovieTitle = x.Title,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF_MOVIIE),
                        VoteCount = x.TblMovieVote.Count (),
                        VoteAverage = x.TblMovieVote.Any () ? x.TblMovieVote.Average (x => x.Mark) : 0
                }).ToListAsync ();
            return similarMovies;
        }

        // view model
        public class ArtistsVm : VoteHelperVm {
            public long AMRId { get; set; }
            public long ArtistId { get; set; }
            public string FullName { get; set; }
            public string FriendlyUrl { get; set; }
            public byte? UserMark { get; set; }
            public CinemaRoleType ArtistRole { get; set; }
            public byte HelperArtistSort { get; set; }
            public string ArtistRoleTitle => EnumExtensions.GetDisplayName ((CinemaRoleType) ArtistRole);
        }

        public class SerialInfoVm {
            public long SeasonId { get; set; }

            public string Season { get; set; }

            public List<ChapterVm> Chapters { get; set; }
        }

        public class SimilarMoviesVm : VoteHelperVm {
            public long Id { get; set; }
            public string MovieTitle { get; set; }

            public string FriendlyUrl { get; set; }

            // public FileHelperVm FileView { get; set; }
        }

        public class ChapterVm {
            public long ChapterId { get; set; }

            public string Chapter { get; set; }

            public string FriendlyUrl { get; set; }

            public decimal Vote { get; set; }

            public byte? UserMark { get; set; }
        }
    }
}