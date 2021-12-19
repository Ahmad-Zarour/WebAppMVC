using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconWebAppMVC.Migrations
{
    public partial class Seededuserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "984db502-aaa1-471e-a9b6-bf3cb26d35da", "1ba7eb3e-ebdb-47ed-a5bd-83c7217fbb5d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ba7eb3e-ebdb-47ed-a5bd-83c7217fbb5d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "984db502-aaa1-471e-a9b6-bf3cb26d35da");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa20607c-b5a8-4361-9519-2f36041c1689", "3d6723af-7c4d-477c-9731-2b42b6570f41", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab3cfbf3-ca0d-4fdc-b6ac-be19d4b28af0", "a51353a9-1992-4968-bb19-ca9259da2ca5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ab3cfbf3-ca0d-4fdc-b6ac-be19d4b28af0", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "11d85f68-992c-4eca-8c77-63a11a89943f", "admin@admin.com", false, "First", "Last", false, null, "ADMIM@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEPP1GcFagNbvv9uLPOhI/B72I2sV6KusB99ZGWBli7DokUPyWxP3vQHt2z/3uq3G2Q==", null, false, "282769e5-1f66-4f7c-9307-5e2251aba5c8", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ab3cfbf3-ca0d-4fdc-b6ac-be19d4b28af0", "aa20607c-b5a8-4361-9519-2f36041c1689" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab3cfbf3-ca0d-4fdc-b6ac-be19d4b28af0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ab3cfbf3-ca0d-4fdc-b6ac-be19d4b28af0", "aa20607c-b5a8-4361-9519-2f36041c1689" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa20607c-b5a8-4361-9519-2f36041c1689");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab3cfbf3-ca0d-4fdc-b6ac-be19d4b28af0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ba7eb3e-ebdb-47ed-a5bd-83c7217fbb5d", "6d61d3cb-8154-4855-acf9-b105d8b65fda", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "984db502-aaa1-471e-a9b6-bf3cb26d35da", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0e75ddd2-8270-48df-8b5e-49284a1c06e9", "admin@admin.com", false, "First", "Last", false, null, "ADMIM@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEGoaKiTzHvozQDAl235CZbPxMKGCiVjEBH7Zr5qyjQWmOv9D+UNyszXD9pCa4/4l7A==", null, false, "61051327-2c61-475a-bc04-b2c2bee25faa", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "984db502-aaa1-471e-a9b6-bf3cb26d35da", "1ba7eb3e-ebdb-47ed-a5bd-83c7217fbb5d" });
        }
    }
}
