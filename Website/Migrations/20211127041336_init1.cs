using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblArtist",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KeyWord = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblArtist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCinemaRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCinemaRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCinemaRole_TblCinemaRole_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TblCinemaRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblJenre",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblJustLover",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AnswerNO = table.Column<byte>(type: "tinyint", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Question = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Source = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJustLover", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblMovie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Interval = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    KeyWord = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Source = table.Column<string>(type: "ntext", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMovie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblProvince",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProvince_TblProvince_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TblProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblArtistCinemaRole",
                columns: table => new
                {
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    CinemaRoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblArtistCinemaRole", x => new { x.CinemaRoleId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_TblArtistCinemaRole_TblArtist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "TblArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblArtistCinemaRole_TblCinemaRole_CinemaRoleId",
                        column: x => x.CinemaRoleId,
                        principalTable: "TblCinemaRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblVtyStarsWar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    KeyWord = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    JenreId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Question = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Source = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVtyStarsWar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblVtyStarsWar_TblJenre_JenreId",
                        column: x => x.JenreId,
                        principalTable: "TblJenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblArtistMovieRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    CinemaRoleId = table.Column<long>(type: "bigint", nullable: false),
                    MovieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblArtistMovieRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblArtistMovieRole_TblArtist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "TblArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblArtistMovieRole_TblCinemaRole_CinemaRoleId",
                        column: x => x.CinemaRoleId,
                        principalTable: "TblCinemaRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblArtistMovieRole_TblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "TblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblMovieJenre",
                columns: table => new
                {
                    JenreId = table.Column<long>(type: "bigint", nullable: false),
                    MovieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMovieJenre", x => new { x.JenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_TblMovieJenre_TblJenre_JenreId",
                        column: x => x.JenreId,
                        principalTable: "TblJenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblMovieJenre_TblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "TblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblSerialInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<byte>(type: "tinyint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    MovieId = table.Column<long>(type: "bigint", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSerialInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSerialInfo_TblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "TblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblSerialInfo_TblSerialInfo_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TblSerialInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Education = table.Column<byte>(type: "tinyint", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    TblProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TblProvince_TblProvinceId",
                        column: x => x.TblProvinceId,
                        principalTable: "TblProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblMovieTags",
                columns: table => new
                {
                    TagsId = table.Column<long>(type: "bigint", nullable: false),
                    MovieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMovieTags", x => new { x.MovieId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_TblMovieTags_TblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "TblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblMovieTags_TblTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TblTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblVtyStarsWarOptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    VtyStarsWarId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVtyStarsWarOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblVtyStarsWarOptions_TblVtyStarsWar_VtyStarsWarId",
                        column: x => x.VtyStarsWarId,
                        principalTable: "TblVtyStarsWar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblVtyStarsWarTags",
                columns: table => new
                {
                    TagsId = table.Column<long>(type: "bigint", nullable: false),
                    VtyStarsWarId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVtyStarsWarTags", x => new { x.VtyStarsWarId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_TblVtyStarsWarTags_TblTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TblTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblVtyStarsWarTags_TblVtyStarsWar_VtyStarsWarId",
                        column: x => x.VtyStarsWarId,
                        principalTable: "TblVtyStarsWar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblArtistVote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    ArtistMovieRoleId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblArtistVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblArtistVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblArtistVote_TblArtistMovieRole_ArtistMovieRoleId",
                        column: x => x.ArtistMovieRoleId,
                        principalTable: "TblArtistMovieRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblComment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    VtyStarsWarId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblComment_TblVtyStarsWar_VtyStarsWarId",
                        column: x => x.VtyStarsWarId,
                        principalTable: "TblVtyStarsWar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblJustLoverAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerNO = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JustLoverId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJustLoverAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblJustLoverAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblJustLoverAnswers_TblJustLover_JustLoverId",
                        column: x => x.JustLoverId,
                        principalTable: "TblJustLover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblJustLoverWinner",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JustLoverId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJustLoverWinner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblJustLoverWinner_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblJustLoverWinner_TblJustLover_JustLoverId",
                        column: x => x.JustLoverId,
                        principalTable: "TblJustLover",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblMovieVote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMovieVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblMovieVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblMovieVote_TblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "TblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblSerialVote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialInfoId = table.Column<long>(type: "bigint", nullable: false),
                    TblSerialInfoId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSerialVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSerialVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblSerialVote_TblSerialInfo_TblSerialInfoId",
                        column: x => x.TblSerialInfoId,
                        principalTable: "TblSerialInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblUserCinemaRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CinemaRoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserCinemaRole", x => new { x.CinemaRoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TblUserCinemaRole_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblUserCinemaRole_TblCinemaRole_CinemaRoleId",
                        column: x => x.CinemaRoleId,
                        principalTable: "TblCinemaRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUserResume",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserResume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUserResume_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblUserVote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<byte>(type: "tinyint", nullable: false),
                    VoterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUserVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblVtyStarWarUserVote",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VtyStarsWarOptionsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVtyStarWarUserVote", x => new { x.UserId, x.VtyStarsWarOptionsId });
                    table.ForeignKey(
                        name: "FK_TblVtyStarWarUserVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblVtyStarWarUserVote_TblVtyStarsWarOptions_VtyStarsWarOptionsId",
                        column: x => x.VtyStarsWarOptionsId,
                        principalTable: "TblVtyStarsWarOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fe773c6-7250-48bd-8f34-2b3dfebda37f", "13704fe3-2b64-4c60-beeb-51e3dd626306", "User", "User" },
                    { "bf38c102-d678-4f73-9e3d-4809a259e5e8", "c19f954e-e4f8-41d8-ab18-1a5209f23e07", "Owner", "Owner" },
                    { "c7c4a2d5-e891-4702-9ebe-87fe830028c2", "fbc91fd2-d3aa-443e-917f-8f593d8b8964", "Artist", "Artist" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Bio", "BirthDate", "ConcurrencyStamp", "DateCreated", "Education", "Email", "EmailConfirmed", "FullName", "IsAvailable", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProvinceId", "SecurityStamp", "TblProvinceId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "da536d4e-8723-44a3-a62f-b867c3f83f0c", 0, null, null, null, "edbc5cdf-5eb3-48c8-a69b-e31118c499a5", new DateTime(2021, 11, 27, 7, 43, 35, 585, DateTimeKind.Local).AddTicks(8360), (byte)1, "mehrshad@gmail.com", true, null, true, false, null, "mehrshad@gmail.com", "mehrshad", "AQAAAAEAACcQAAAAEMlyLE6noxGTMJdEXGypb3Yfb0P8XC67cfHBZ3ayDPRYOPX2mZY4RKykm0NkZmGqJw==", null, false, null, "", null, false, "mehrshad" });

            migrationBuilder.InsertData(
                table: "TblCinemaRole",
                columns: new[] { "Id", "ParentId", "Title", "Type" },
                values: new object[,]
                {
                    { 16L, null, "سایر", (byte)16 },
                    { 15L, null, "طراح نور", (byte)15 },
                    { 14L, null, "دراماتورژ", (byte)14 },
                    { 13L, null, "نمایشنامه نویس", (byte)13 },
                    { 12L, null, "طراح گریم", (byte)12 },
                    { 11L, null, "صداگذار", (byte)11 },
                    { 1L, null, "تهیه کننده", (byte)1 },
                    { 9L, null, "طراح لباس", (byte)9 },
                    { 8L, null, "طراح صحنه", (byte)8 },
                    { 7L, null, "آهنگساز", (byte)7 },
                    { 6L, null, "تدوین گر", (byte)6 },
                    { 5L, null, "مدیر تصویر برداری", (byte)5 },
                    { 10L, null, "صدابردار", (byte)10 },
                    { 2L, null, "کارگردان", (byte)2 },
                    { 3L, null, "بازیگر", (byte)3 },
                    { 4L, null, "فیلم نامه نویس", (byte)4 }
                });

            migrationBuilder.InsertData(
                table: "TblJenre",
                columns: new[] { "Id", "Title", "Type" },
                values: new object[,]
                {
                    { 16L, "جنگی", (byte)16 },
                    { 14L, "ورزشی", (byte)14 },
                    { 13L, "اجتماعی", (byte)13 },
                    { 12L, "جنایی", (byte)12 },
                    { 11L, "خانوادگی", (byte)11 },
                    { 15L, "دینی", (byte)15 },
                    { 9L, "تاریخی", (byte)9 },
                    { 8L, "درام", (byte)8 },
                    { 7L, "ترسناک", (byte)7 },
                    { 6L, "کمدی عاشقانه", (byte)6 },
                    { 5L, "عاشقانه", (byte)5 },
                    { 4L, "کمدی", (byte)4 },
                    { 3L, "اکشن", (byte)3 },
                    { 2L, "انیمیشن", (byte)2 },
                    { 10L, "مستند", (byte)10 },
                    { 1L, "کودک", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "TblProvince",
                columns: new[] { "Id", "ParentId", "Title" },
                values: new object[,]
                {
                    { 87L, null, "کردستان" },
                    { 34L, null, "کرمان" },
                    { 83L, null, "کرمانشاه" },
                    { 74L, null, "کهگیلویه وبویراحمد	" },
                    { 17L, null, "گلستان" },
                    { 13L, null, "گیلان" }
                });

            migrationBuilder.InsertData(
                table: "TblProvince",
                columns: new[] { "Id", "ParentId", "Title" },
                values: new object[,]
                {
                    { 76L, null, "هرمزگان" },
                    { 11L, null, "مازندران" },
                    { 86L, null, "مرکزی" },
                    { 81L, null, "همدان" },
                    { 35L, null, "یزد" },
                    { 25L, null, "قم	" },
                    { 66L, null, "لرستان" },
                    { 28L, null, "قزوین" },
                    { 84L, null, "ایلام" },
                    { 54L, null, "سیستان و بلوچستان" },
                    { 23L, null, "سمنان" },
                    { 24L, null, "زنجان" },
                    { 61L, null, "خوزستان" },
                    { 58L, null, "خراسان شمالی" },
                    { 51L, null, "خراسان رضوی" },
                    { 56L, null, "خراسان جنوبی" },
                    { 38L, null, "چهارمحال و بختیاری" },
                    { 21L, null, "تهران" },
                    { 77L, null, "بوشهر" },
                    { 26L, null, "البرز" },
                    { 31L, null, "اصفهان" },
                    { 45L, null, "اردبیل" },
                    { 44L, null, "آذربایجان غربی" },
                    { 71L, null, "فارس" },
                    { 41L, null, "آذربایجان شرقی" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bf38c102-d678-4f73-9e3d-4809a259e5e8", "da536d4e-8723-44a3-a62f-b867c3f83f0c" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TblProvinceId",
                table: "AspNetUsers",
                column: "TblProvinceId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TblArtistCinemaRole_ArtistId",
                table: "TblArtistCinemaRole",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_TblArtistMovieRole_ArtistId",
                table: "TblArtistMovieRole",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_TblArtistMovieRole_CinemaRoleId",
                table: "TblArtistMovieRole",
                column: "CinemaRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblArtistMovieRole_MovieId",
                table: "TblArtistMovieRole",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TblArtistVote_ArtistMovieRoleId",
                table: "TblArtistVote",
                column: "ArtistMovieRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblArtistVote_UserId",
                table: "TblArtistVote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCinemaRole_ParentId",
                table: "TblCinemaRole",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblComment_UserId",
                table: "TblComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblComment_VtyStarsWarId",
                table: "TblComment",
                column: "VtyStarsWarId");

            migrationBuilder.CreateIndex(
                name: "IX_TblJustLoverAnswers_JustLoverId",
                table: "TblJustLoverAnswers",
                column: "JustLoverId");

            migrationBuilder.CreateIndex(
                name: "IX_TblJustLoverAnswers_UserId",
                table: "TblJustLoverAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblJustLoverWinner_JustLoverId",
                table: "TblJustLoverWinner",
                column: "JustLoverId");

            migrationBuilder.CreateIndex(
                name: "IX_TblJustLoverWinner_UserId",
                table: "TblJustLoverWinner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMovieJenre_MovieId",
                table: "TblMovieJenre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMovieTags_TagsId",
                table: "TblMovieTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMovieVote_MovieId",
                table: "TblMovieVote",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMovieVote_UserId",
                table: "TblMovieVote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProvince_ParentId",
                table: "TblProvince",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSerialInfo_MovieId",
                table: "TblSerialInfo",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSerialInfo_ParentId",
                table: "TblSerialInfo",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSerialVote_TblSerialInfoId",
                table: "TblSerialVote",
                column: "TblSerialInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSerialVote_UserId",
                table: "TblSerialVote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserCinemaRole_UserId",
                table: "TblUserCinemaRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserResume_UserId",
                table: "TblUserResume",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserVote_UserId",
                table: "TblUserVote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblVtyStarsWar_JenreId",
                table: "TblVtyStarsWar",
                column: "JenreId");

            migrationBuilder.CreateIndex(
                name: "IX_TblVtyStarsWarOptions_VtyStarsWarId",
                table: "TblVtyStarsWarOptions",
                column: "VtyStarsWarId");

            migrationBuilder.CreateIndex(
                name: "IX_TblVtyStarsWarTags_TagsId",
                table: "TblVtyStarsWarTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_TblVtyStarWarUserVote_VtyStarsWarOptionsId",
                table: "TblVtyStarWarUserVote",
                column: "VtyStarsWarOptionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TblArtistCinemaRole");

            migrationBuilder.DropTable(
                name: "TblArtistVote");

            migrationBuilder.DropTable(
                name: "TblComment");

            migrationBuilder.DropTable(
                name: "TblJustLoverAnswers");

            migrationBuilder.DropTable(
                name: "TblJustLoverWinner");

            migrationBuilder.DropTable(
                name: "TblMovieJenre");

            migrationBuilder.DropTable(
                name: "TblMovieTags");

            migrationBuilder.DropTable(
                name: "TblMovieVote");

            migrationBuilder.DropTable(
                name: "TblSerialVote");

            migrationBuilder.DropTable(
                name: "TblUserCinemaRole");

            migrationBuilder.DropTable(
                name: "TblUserResume");

            migrationBuilder.DropTable(
                name: "TblUserVote");

            migrationBuilder.DropTable(
                name: "TblVtyStarsWarTags");

            migrationBuilder.DropTable(
                name: "TblVtyStarWarUserVote");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TblArtistMovieRole");

            migrationBuilder.DropTable(
                name: "TblJustLover");

            migrationBuilder.DropTable(
                name: "TblSerialInfo");

            migrationBuilder.DropTable(
                name: "TblTags");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TblVtyStarsWarOptions");

            migrationBuilder.DropTable(
                name: "TblArtist");

            migrationBuilder.DropTable(
                name: "TblCinemaRole");

            migrationBuilder.DropTable(
                name: "TblMovie");

            migrationBuilder.DropTable(
                name: "TblProvince");

            migrationBuilder.DropTable(
                name: "TblVtyStarsWar");

            migrationBuilder.DropTable(
                name: "TblJenre");
        }
    }
}
