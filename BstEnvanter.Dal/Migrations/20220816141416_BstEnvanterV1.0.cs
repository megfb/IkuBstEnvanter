using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    public partial class BstEnvanterV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainBoardid",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cpuId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gpuId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "hardDriveId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mainBoradId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ramId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cpu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Gpu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HardDrive",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDrive", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "Ram",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ram", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_cpuId",
                table: "Product",
                column: "cpuId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_gpuId",
                table: "Product",
                column: "gpuId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_hardDriveId",
                table: "Product",
                column: "hardDriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MainBoardid",
                table: "Product",
                column: "MainBoardid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ramId",
                table: "Product",
                column: "ramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cpu_cpuId",
                table: "Product",
                column: "cpuId",
                principalTable: "Cpu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Gpu_gpuId",
                table: "Product",
                column: "gpuId",
                principalTable: "Gpu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_HardDrive_hardDriveId",
                table: "Product",
                column: "hardDriveId",
                principalTable: "HardDrive",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_MainBoard_MainBoardid",
                table: "Product",
                column: "MainBoardid",
                principalTable: "MainBoard",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Ram_ramId",
                table: "Product",
                column: "ramId",
                principalTable: "Ram",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cpu_cpuId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Gpu_gpuId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_HardDrive_hardDriveId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_MainBoard_MainBoardid",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Ram_ramId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Cpu");

            migrationBuilder.DropTable(
                name: "Gpu");

            migrationBuilder.DropTable(
                name: "HardDrive");

            migrationBuilder.DropTable(
                name: "MainBoard");

            migrationBuilder.DropTable(
                name: "Ram");

            migrationBuilder.DropIndex(
                name: "IX_Product_cpuId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_gpuId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_hardDriveId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_MainBoardid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ramId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MainBoardid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "cpuId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "gpuId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "hardDriveId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "mainBoradId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ramId",
                table: "Product");
        }
    }
}
