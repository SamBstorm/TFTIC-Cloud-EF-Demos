using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo01.Migrations
{
    /// <inheritdoc />
    public partial class add_serverdetails_with_datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServerDetails",
                columns: table => new
                {
                    ServerDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "CHAR(15)", nullable: false),
                    SoftwareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerDetails", x => x.ServerDetailsId);
                    table.CheckConstraint("CK_ServerDetails_IpAddress", "[IpAddress] LIKE '___.___.___.___' AND ISNUMERIC(REPLACE([IpAddress],'.','')) = 1");
                    table.ForeignKey(
                        name: "FK_ServerDetails_Softs",
                        column: x => x.SoftwareId,
                        principalTable: "Softs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ServerDetails",
                columns: new[] { "ServerDetailsId", "IpAddress", "SoftwareId" },
                values: new object[,]
                {
                    { 1, "127.000.000.001", 3 },
                    { 2, "127.000.000.001", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServerDetails_SoftwareId",
                table: "ServerDetails",
                column: "SoftwareId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerDetails");
        }
    }
}
