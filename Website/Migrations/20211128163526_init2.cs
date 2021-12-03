using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fe773c6-7250-48bd-8f34-2b3dfebda37f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c4a2d5-e891-4702-9ebe-87fe830028c2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bf38c102-d678-4f73-9e3d-4809a259e5e8", "da536d4e-8723-44a3-a62f-b867c3f83f0c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf38c102-d678-4f73-9e3d-4809a259e5e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da536d4e-8723-44a3-a62f-b867c3f83f0c");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "TblMovie",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "238e8b38-5a1b-433b-b152-2e9674e390f7", "ff60834d-da13-4ff4-9ec4-9a0037ea3ce1", "Owner", "Owner" },
                    { "ded706c4-9719-49dc-845c-0b7bee0145d2", "f61ec13a-9110-4e9e-a617-4dbc7ac5eee2", "Artist", "Artist" },
                    { "b0602d74-2cf5-4c9d-bd45-06fbf30b2c7d", "01252311-fdef-48b3-8f87-6fd908ae47bc", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Bio", "BirthDate", "ConcurrencyStamp", "DateCreated", "Education", "Email", "EmailConfirmed", "FullName", "IsAvailable", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProvinceId", "SecurityStamp", "TblProvinceId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a9e57d9c-5d9e-4397-9959-24994049893f", 0, null, null, null, "65a071e5-b7c9-4f2e-b409-eac845275065", new DateTime(2021, 11, 28, 20, 5, 25, 435, DateTimeKind.Local).AddTicks(4085), (byte)1, "mehrshad@gmail.com", true, null, true, false, null, "mehrshad@gmail.com", "mehrshad", "AQAAAAEAACcQAAAAENtoJAjUFf58Tgx5QF6zluQCkYxyJDN3Yp6AsG3PiP726ghfa5wD09FZ+3H7mvWdvQ==", null, false, null, "", null, false, "mehrshad" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "238e8b38-5a1b-433b-b152-2e9674e390f7", "a9e57d9c-5d9e-4397-9959-24994049893f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0602d74-2cf5-4c9d-bd45-06fbf30b2c7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ded706c4-9719-49dc-845c-0b7bee0145d2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "238e8b38-5a1b-433b-b152-2e9674e390f7", "a9e57d9c-5d9e-4397-9959-24994049893f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "238e8b38-5a1b-433b-b152-2e9674e390f7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9e57d9c-5d9e-4397-9959-24994049893f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "TblMovie",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf38c102-d678-4f73-9e3d-4809a259e5e8", "c19f954e-e4f8-41d8-ab18-1a5209f23e07", "Owner", "Owner" },
                    { "c7c4a2d5-e891-4702-9ebe-87fe830028c2", "fbc91fd2-d3aa-443e-917f-8f593d8b8964", "Artist", "Artist" },
                    { "5fe773c6-7250-48bd-8f34-2b3dfebda37f", "13704fe3-2b64-4c60-beeb-51e3dd626306", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Bio", "BirthDate", "ConcurrencyStamp", "DateCreated", "Education", "Email", "EmailConfirmed", "FullName", "IsAvailable", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProvinceId", "SecurityStamp", "TblProvinceId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "da536d4e-8723-44a3-a62f-b867c3f83f0c", 0, null, null, null, "edbc5cdf-5eb3-48c8-a69b-e31118c499a5", new DateTime(2021, 11, 27, 7, 43, 35, 585, DateTimeKind.Local).AddTicks(8360), (byte)1, "mehrshad@gmail.com", true, null, true, false, null, "mehrshad@gmail.com", "mehrshad", "AQAAAAEAACcQAAAAEMlyLE6noxGTMJdEXGypb3Yfb0P8XC67cfHBZ3ayDPRYOPX2mZY4RKykm0NkZmGqJw==", null, false, null, "", null, false, "mehrshad" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bf38c102-d678-4f73-9e3d-4809a259e5e8", "da536d4e-8723-44a3-a62f-b867c3f83f0c" });
        }
    }
}
