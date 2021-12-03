using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte>(
                name: "Subject",
                table: "TblVtyStarsWar",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "351205b2-0172-4c04-88a5-cd88667b300d", "ecff8407-42c3-47ce-b6aa-0932b07caf0a", "Owner", "Owner" },
                    { "8d0a4154-a33c-4c8e-99e8-b7d4616e82bb", "78a73274-3ab5-4f11-8653-52a3769a5a97", "Artist", "Artist" },
                    { "1d170224-d92b-43e4-a9cf-c0f0c5901644", "66ded6e7-ab24-4523-ba75-688c92487060", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Bio", "BirthDate", "ConcurrencyStamp", "DateCreated", "Education", "Email", "EmailConfirmed", "FullName", "IsAvailable", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProvinceId", "SecurityStamp", "TblProvinceId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "73cce5bb-14aa-41b7-a283-0b8a32c7c546", 0, null, null, null, "9e3dc198-9918-4f57-bca5-262c8c3117a2", new DateTime(2021, 11, 30, 14, 35, 44, 111, DateTimeKind.Local).AddTicks(5067), (byte)1, "mehrshad@gmail.com", true, null, true, false, null, "mehrshad@gmail.com", "mehrshad", "AQAAAAEAACcQAAAAELjX1sX/vtkFLbYkO0N8gG7jW+kxkEU6qiEJleWgIz1WQMRxWh8msfS56b9xyBLtJw==", null, false, null, "", null, false, "mehrshad" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "351205b2-0172-4c04-88a5-cd88667b300d", "73cce5bb-14aa-41b7-a283-0b8a32c7c546" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d170224-d92b-43e4-a9cf-c0f0c5901644");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d0a4154-a33c-4c8e-99e8-b7d4616e82bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "351205b2-0172-4c04-88a5-cd88667b300d", "73cce5bb-14aa-41b7-a283-0b8a32c7c546" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "351205b2-0172-4c04-88a5-cd88667b300d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73cce5bb-14aa-41b7-a283-0b8a32c7c546");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "TblVtyStarsWar");

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
    }
}
