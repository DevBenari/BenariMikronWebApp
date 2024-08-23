using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class UpdateTambahPasienBaru4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamaPenjamin",
                schema: "dbo",
                table: "AdmPasienBaru");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NamaPenjamin",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
