using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconWebAppMVC.Migrations
{
    public partial class Seedsomeextradata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityModelCityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityModelCityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityModelCityId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "Germany" },
                    { 2, "Italy" },
                    { 3, "Sweden" },
                    { 4, "Norway" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "LanguageName" },
                values: new object[,]
                {
                    { 1, "German" },
                    { 2, "Swedish" },
                    { 3, "Norwegian" },
                    { 4, "italian" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[,]
                {
                    { 2, "Berlin", 1 },
                    { 3, "Hanover", 1 },
                    { 1, "Roma", 2 },
                    { 4, "Gothenburg", 3 },
                    { 5, "Stockholm", 3 },
                    { 6, "Oslo", 4 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "CityId", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, 2, "Masoud Ozel", "+49-55883211" },
                    { 9, 3, "Michel Moler", "+49-73225008" },
                    { 6, 1, "Sandro Mazzola", "+39-73225588" },
                    { 7, 1, "Marco Tardeli ", "+39-73225588" },
                    { 4, 4, "Anna Maria", "+46-732001874" },
                    { 5, 4, "Samanta Hanson", "+46-73201177" },
                    { 1, 5, "Johan Strom", "+46-73225588" },
                    { 3, 5, "Angela Mark", "+49-55880011" },
                    { 8, 6, "Rita Nord", "+47-73225008" }
                });

            migrationBuilder.InsertData(
                table: "Person_Language",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 9, 1 },
                    { 6, 4 },
                    { 7, 4 },
                    { 4, 2 },
                    { 5, 2 },
                    { 1, 2 },
                    { 3, 1 },
                    { 8, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "Person_Language",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CityModelCityId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityModelCityId",
                table: "People",
                column: "CityModelCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityModelCityId",
                table: "People",
                column: "CityModelCityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
