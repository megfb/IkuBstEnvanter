using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    public partial class BstEnvanterV15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_CLocation_cLocationId",
                table: "Personel");

            migrationBuilder.AlterColumn<int>(
                name: "cLocationId",
                table: "Personel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_CLocation_cLocationId",
                table: "Personel",
                column: "cLocationId",
                principalTable: "CLocation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_CLocation_cLocationId",
                table: "Personel");

            migrationBuilder.AlterColumn<int>(
                name: "cLocationId",
                table: "Personel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_CLocation_cLocationId",
                table: "Personel",
                column: "cLocationId",
                principalTable: "CLocation",
                principalColumn: "id");
        }
    }
}
