using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo01.Migrations
{
    /// <inheritdoc />
    public partial class adddatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Softs",
                columns: new[] { "Id", "Description", "IsOnline", "IsSplitScreen", "Name", "PegiClassification", "ReleaseDate", "Type" },
                values: new object[,]
                {
                    { 1, "Jeu de réflexion, puzle game, style SuperFactory.", false, false, "Shapez 2", "NaN", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "Jeu de course Arcade", true, true, "TrackMania", "+3", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, "Action-RPG dans un univers cyber-punk, shooter-looter", true, false, "The Ascent", "+18", new DateTime(2021, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 4, "TPS PVP PVE spatial", true, false, "Destiny 2", "+16", new DateTime(2017, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "Softs",
                columns: new[] { "Id", "Description", "IsMobile", "IsMultimedia", "IsOnline", "Name", "ReleaseDate", "Type" },
                values: new object[,]
                {
                    { 5, "Application de rencontre", true, false, true, "Tinder", new DateTime(2012, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "Application de partage de contenu multimédia, réseau social", true, true, true, "Instagram", new DateTime(2010, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "Application de visualisation de manga, service de streaming", true, true, true, "CrunchyRoll", new DateTime(2006, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "IDE pour le framework .net", false, false, true, "Visual Studio", new DateTime(1997, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
