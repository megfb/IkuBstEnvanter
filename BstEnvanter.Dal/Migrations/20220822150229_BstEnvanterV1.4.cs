using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    public partial class BstEnvanterV14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prop1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "prop2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "prop3",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "prop4",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "cLocationId",
                table: "Personel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personel_cLocationId",
                table: "Personel",
                column: "cLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_CLocation_cLocationId",
                table: "Personel",
                column: "cLocationId",
                principalTable: "CLocation",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_CLocation_cLocationId",
                table: "Personel");

            migrationBuilder.DropIndex(
                name: "IX_Personel_cLocationId",
                table: "Personel");

            migrationBuilder.DropColumn(
                name: "cLocationId",
                table: "Personel");

            migrationBuilder.AddColumn<string>(
                name: "prop1",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prop2",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prop3",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prop4",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
