using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

// 
using DbLayer.Entities;
using DbLayer.Enums;
using HpLayer.Extensions;

namespace DbLayer.Identity {
    public class AppUser : IdentityUser {
        public string Avatar { get; set; }

        public string FullName { get; set; }

        [NotMapped]
        public string DisplayName => FullName ?? UserName;

        [Column (TypeName = "smalldatetime")]
        public DateTime? BirthDate { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public EducationType Education { get; set; } = EducationType.None;

        [NotMapped]
        public string EducationTitle =>
            EnumExtensions.GetDisplayName ((EducationType) Education);

        /// <summary>
        /// در دسترس بودن
        /// </summary>
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// توضیحات سابقه کارس
        /// </summary>
        public string Bio { get; set; }

        // Foreign key
        public long? ProvinceId { get; set; }

        public TblProvince TblProvince { get; set; }

        // Collection
        public ICollection<TblUserVote> TblUserVote { set; get; }
        public ICollection<TblMovieVote> TblMovieVote { set; get; }
        public ICollection<TblArtistVote> TblArtistVote { set; get; }
        public ICollection<TblUserResume> TblUserResume { set; get; }
        public ICollection<TblUserCinemaRole> TblUserCinemaRole { set; get; }
        public ICollection<TblJustLoverWinner> TblJustLoverWinner { set; get; }
        public ICollection<TblJustLoverAnswers> TblJustLoverAnswers { set; get; }
        public ICollection<TblVtyStarWarUserVote> TblVtyStarWarUserVote { set; get; }
        public ICollection<TblComment> TblComment { set; get; }
    }

    public class TblVtyStarWarUserVote {
        public string UserId { get; set; }

        public AppUser AppUser { get; set; }

        public long VtyStarsWarOptionsId { get; set; }
        public TblVtyStarsWarOptions TblVtyStarsWarOptions { get; set; }
    }

    public class TblUserCinemaRole {
        public string UserId { get; set; }

        [ForeignKey ("UserId")]
        public AppUser AppUser { get; set; }

        public long CinemaRoleId { get; set; }

        [ForeignKey ("CinemaRoleId")]
        public TblCinemaRole TblCinemaRole { get; set; }
    }
}