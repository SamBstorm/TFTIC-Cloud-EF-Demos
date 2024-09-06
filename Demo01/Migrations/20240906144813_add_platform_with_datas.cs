using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo01.Migrations
{
    /// <inheritdoc />
    public partial class add_platform_with_datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.ID);
                    table.CheckConstraint("CK_Platform_Name", "LEN([Name]) > 1");
                });

            migrationBuilder.CreateTable(
                name: "PlatformGame",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformGame", x => new { x.GameId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_PlatformGame_Game",
                        column: x => x.GameId,
                        principalTable: "Softs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformGame_Platform",
                        column: x => x.PlatformId,
                        principalTable: "Platform",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "PlayStation" },
                    { 2, "Switch" },
                    { 3, "XBox ONE" },
                    { 4, "PC" }
                });

            migrationBuilder.InsertData(
                table: "PlatformGame",
                columns: new[] { "GameId", "PlatformId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 3 },
                    { 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGame_PlatformId",
                table: "PlatformGame",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformGame");

            migrationBuilder.DropTable(
                name: "Platform");
        }
    }
}
