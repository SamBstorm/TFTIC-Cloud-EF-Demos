using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo01.Migrations
{
    /// <inheritdoc />
    public partial class add_editor_with_datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditorId",
                table: "Softs",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Editor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editor", x => x.ID);
                    table.CheckConstraint("CK_Editor_Name", "LEN([Name]) > 1");
                });

            migrationBuilder.InsertData(
                table: "Editor",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Unknown" },
                    { 2, "Ubisoft" },
                    { 3, "Polyphony Digital" },
                    { 4, "Bungie" },
                    { 5, "Neon Giant" },
                    { 6, "Microsoft" },
                    { 7, "Meta" }
                });

            migrationBuilder.UpdateData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 1,
                column: "EditorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 2,
                column: "EditorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 3,
                column: "EditorId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 4,
                column: "EditorId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 5,
                column: "EditorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 6,
                column: "EditorId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 7,
                column: "EditorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Softs",
                keyColumn: "Id",
                keyValue: 8,
                column: "EditorId",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_Softs_EditorId",
                table: "Softs",
                column: "EditorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Editor",
                table: "Softs",
                column: "EditorId",
                principalTable: "Editor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Software_Editor",
                table: "Softs");

            migrationBuilder.DropTable(
                name: "Editor");

            migrationBuilder.DropIndex(
                name: "IX_Softs_EditorId",
                table: "Softs");

            migrationBuilder.DropColumn(
                name: "EditorId",
                table: "Softs");
        }
    }
}
