using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo01.Migrations
{
    /// <inheritdoc />
    public partial class InitEF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Softs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsMobile = table.Column<bool>(type: "bit", nullable: true),
                    IsMultimedia = table.Column<bool>(type: "bit", nullable: true),
                    PegiClassification = table.Column<string>(type: "CHAR(3)", nullable: true),
                    IsSplitScreen = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softs", x => x.Id);
                    table.CheckConstraint("CK_Software_Description", "LEN([Description]) > 10");
                    table.CheckConstraint("CK_Software_Name", "LEN([Name]) > 0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Softs_Name_ReleaseDate",
                table: "Softs",
                columns: new[] { "Name", "ReleaseDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Softs");
        }
    }
}
