using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class changeReligionAndLastEducationInNewPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agama",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "PendidikanTerakhir",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.AddColumn<Guid>(
                name: "LastEducationId",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReligionId",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEducationId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.AddColumn<string>(
                name: "Agama",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PendidikanTerakhir",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
