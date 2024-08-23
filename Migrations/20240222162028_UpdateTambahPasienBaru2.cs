using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class UpdateTambahPasienBaru2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NamaPerusahaanPenjamin",
                schema: "dbo",
                table: "AdmPasienBaru",
                newName: "Perusahaan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Perusahaan",
                schema: "dbo",
                table: "AdmPasienBaru",
                newName: "NamaPerusahaanPenjamin");
        }
    }
}
