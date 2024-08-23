using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class deleteSukuPasienBaru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SukuPasien",
                schema: "dbo",
                table: "AdmPasienBaru");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SukuPasien",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
