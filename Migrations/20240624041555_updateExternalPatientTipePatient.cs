using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateExternalPatientTipePatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipePasien",
                schema: "dbo",
                table: "PtrExternalPatientOptik");

            migrationBuilder.DropColumn(
                name: "TipePasien",
                schema: "dbo",
                table: "PtrExternalPatientFasilitas");

            migrationBuilder.DropColumn(
                name: "TipePasien",
                schema: "dbo",
                table: "PtrExternalPatientAmbulance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipePasien",
                schema: "dbo",
                table: "PtrExternalPatientOptik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipePasien",
                schema: "dbo",
                table: "PtrExternalPatientFasilitas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipePasien",
                schema: "dbo",
                table: "PtrExternalPatientAmbulance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
