using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateExternalPatientAddModelNegara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Negara",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Negara",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Negara",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "Negara",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");
        }
    }
}
