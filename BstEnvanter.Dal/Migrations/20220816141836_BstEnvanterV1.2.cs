using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    public partial class BstEnvanterV12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mainBoradId",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mainBoradId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
