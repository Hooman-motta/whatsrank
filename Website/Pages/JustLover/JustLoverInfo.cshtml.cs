using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Entities;
using DbLayer.Enums;
using HpLayer.Helper;
using Website.Helper.Utils;
using Website.Service.SrcIdentity.Configure;

namespace Website.Pages.JustLover {
    public class JustLoverInfoModel : PageModel {
        private readonly AppDbContext _context;

        public JustLoverInfoModel (AppDbContext context) { _context = context; }

        [BindProperty (SupportsGet = true)]
        public long Id { get; set; }

        [BindProperty]
        public byte OptionId { get; set; }

        public class ListModel {
            public long Id { get; set; }

            public string Title { get; set; }

            public JustLoverType Type { get; set; }

            public string FriendlyUrl { get; set; }

            public string MusicFramUrl { get; set; }

            public string Source { get; set; }

            public string Question { get; set; }

            public string ReleaseDate { get; set; }

            public KeyValuePair<int, string> option1 { get; set; }
            public KeyValuePair<int, string> option2 { get; set; }
            public KeyValuePair<int, string> option3 { get; set; }
            public KeyValuePair<int, string> option4 { get; set; }

            public byte? UserNo { get; set; }

            public byte AnswerNO { get; set; }

            public bool IsExpired { get; set; }
        }

        public ListModel List { get; set; }

        public async Task OnGetAsync () {
            string userId = null;
            if (User.Identity.IsAuthenticated) {
                userId = User.Identity.GetUserId<string> ();
            }
            List = await _context.TblJustLover
                .Include (x => x.TblJustLoverAnswers)
                .Select (x => new ListModel {
                    Id = x.Id,
                        Title = x.Title,
                        Type = x.Type,
                        FriendlyUrl = x.Type == JustLoverType.Fram ?
                        x.FileUrl.ToFriendlyImage (DefaultImageType.DEF_MUSIC) : x.FileUrl,
                        MusicFramUrl = x.Type != JustLoverType.Fram ? "".ToFriendlyImage (DefaultImageType.DEF_MUSIC) : null,
                        Question = x.Question,
                        ReleaseDate = x.PersianCreatedDate,
                        Source = x.Source,
                        option1 = new KeyValuePair<int, string> (x.TblJustLoverAnswers.Count (x => x.AnswerNO == 1), x.Option1),
                        option2 = new KeyValuePair<int, string> (x.TblJustLoverAnswers.Count (x => x.AnswerNO == 2), x.Option2),
                        option3 = new KeyValuePair<int, string> (x.TblJustLoverAnswers.Count (x => x.AnswerNO == 3), x.Option3),
                        option4 = new KeyValuePair<int, string> (x.TblJustLoverAnswers.Count (x => x.AnswerNO == 4), x.Option4),
                        UserNo = x.TblJustLoverAnswers.Any (x => x.UserId == userId) ?
                        x.TblJustLoverAnswers.FirstOrDefault (x => x.UserId == userId).AnswerNO : null,
                        AnswerNO = x.AnswerNO,
                        IsExpired = x.IsExpired,
                }).AsNoTracking ().FirstOrDefaultAsync (x => x.Id == Id);
        }

        public async Task<IActionResult> OnPostSetVoteAsync () {
            try {
                if (OptionId == 0) {
                    throw new Exception (ConstValues.ErRequest);
                }
                var userId = User.Identity.GetUserId<string> ();
                var justLover = await _context.TblJustLover
                    .Include (x => x.TblJustLoverAnswers.Where (x => x.UserId == userId))
                    .SingleAsync (x => x.Id == Id);

                if (justLover.TblJustLoverAnswers.Any ()) {
                    var answer = justLover.TblJustLoverAnswers.FirstOrDefault ();
                    var answerObject = await _context
                        .TblJustLoverAnswers.FindAsync (answer.Id);
                    answerObject.AnswerNO = OptionId;
                    _context.TblJustLoverAnswers.Update (answerObject);
                    await _context.SaveChangesAsync ();
                } else {
                    await _context.TblJustLoverAnswers
                        .AddAsync (new TblJustLoverAnswers {
                            UserId = userId,
                                AnswerNO = OptionId,
                                JustLoverId = Id
                        });
                    await _context.SaveChangesAsync ();
                }

                return new OkObjectResult (ApiResult.Succeeded (OptionId));
            } catch (Exception ex) {
                ModelState.AddModelError ("", ex.Message);
                var errors = ModelState.ModelStateErrorAsApiResult ();
                return new BadRequestObjectResult (ApiResult.Failed (errors));
            }
        }
    }
}