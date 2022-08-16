using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    public partial class BstEnvanterV13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_MainBoard_MainBoardid",
                table: "Product");

            migrationBuilder.DropTable(
                name: "MainBoard");

            migrationBuilder.DropIndex(
                name: "IX_Product_MainBoardid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MainBoardid",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainBoardid",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainBoard",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainBoard", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_MainBoardid",
                table: "Product",
                column: "MainBoardid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_MainBoard_MainBoardid",
                table: "Product",
                column: "MainBoardid",
                principalTable: "MainBoard",
                principalColumn: "id");
        }
    }
}
