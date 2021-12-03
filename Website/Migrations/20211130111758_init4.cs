using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblVtyStarsWar_TblJenre_JenreId",
                table: "TblVtyStarsWar");

            migrationBuilder.DropIndex(
                name: "IX_TblVtyStarsWar_JenreId",
                table: "TblVtyStarsWar");

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
                name: "JenreId",
                table: "TblVtyStarsWar");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d17df86-bef2-4a8a-a669-9a8f923cb1a9", "67dcf097-ce61-4c25-9ab6-02d10c557d4b", "Owner", "Owner" },
                    { "4a010e28-5dcb-4b03-b322-e297b35ec0b3", "b756bd49-8e96-4e3a-8bfd-6dfe7065041e", "Artist", "Artist" },
                    { "553255fa-d15b-4761-a0de-bee0b807c6e1", "8e2ea8a4-daae-4497-a882-15295cea2882", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Bio", "BirthDate", "ConcurrencyStamp", "DateCreated", "Education", "Email", "EmailConfirmed", "FullName", "IsAvailable", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProvinceId", "SecurityStamp", "TblProvinceId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d50a4889-8caf-4995-a025-3c6e64a58755", 0, null, null, null, "caae4c28-ee3d-4214-8bf1-1370a4592f6a", new DateTime(2021, 11, 30, 14, 47, 57, 367, DateTimeKind.Local).AddTicks(8746), (byte)1, "mehrshad@gmail.com", true, null, true, false, null, "mehrshad@gmail.com", "mehrshad", "AQAAAAEAACcQAAAAEHNio75X4h02ytTnDUFPCt1bSKZCbQvqmXA+u+qSIoluvkaJ5GUSXZko3CFHa/SMHg==", null, false, null, "", null, false, "mehrshad" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d17df86-bef2-4a8a-a669-9a8f923cb1a9", "d50a4889-8caf-4995-a025-3c6e64a58755" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a010e28-5dcb-4b03-b322-e297b35ec0b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "553255fa-d15b-4761-a0de-bee0b807c6e1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d17df86-bef2-4a8a-a669-9a8f923cb1a9", "d50a4889-8caf-4995-a025-3c6e64a58755" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d17df86-bef2-4a8a-a669-9a8f923cb1a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d50a4889-8caf-4995-a025-3c6e64a58755");

            migrationBuilder.AddColumn<long>(
                name: "JenreId",
                table: "TblVtyStarsWar",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_TblVtyStarsWar_JenreId",
                table: "TblVtyStarsWar",
                column: "JenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblVtyStarsWar_TblJenre_JenreId",
                table: "TblVtyStarsWar",
                column: "JenreId",
                principalTable: "TblJenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
