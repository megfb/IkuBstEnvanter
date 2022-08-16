using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    public partial class Nero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "eMail",
                table: "Personel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eMail",
                table: "Personel");
        }
    }
}
