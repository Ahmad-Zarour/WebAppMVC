using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconWebAppMVC.Migrations
{
    public partial class MorePerson_LanguagedataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person_Language",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 7, 3 },
                    { 9, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 9, 4 });
        }
    }
}
