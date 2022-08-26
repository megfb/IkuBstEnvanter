using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    public partial class BstEnvanterV18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roomNo",
                table: "Personel");

            migrationBuilder.AddColumn<int>(
                name: "serviceId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    processNumber = table.Column<int>(type: "int", nullable: false),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    specialist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number = table.Column<int>(type: "int", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateOfEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Status_serviceId",
                table: "Status",
                column: "serviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Service_serviceId",
                table: "Status",
                column: "serviceId",
                principalTable: "Service",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Service_serviceId",
                table: "Status");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Status_serviceId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "Status");

            migrationBuilder.AddColumn<string>(
                name: "roomNo",
                table: "Personel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
