using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class changeGolonganDarahToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GolonganDarah",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.AddColumn<Guid>(
                name: "BloodTypeId",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PtrNewPatient_BloodTypeId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "BloodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PtrNewPatient_HmnBloodType_BloodTypeId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "BloodTypeId",
                principalSchema: "dbo",
                principalTable: "HmnBloodType",
                principalColumn: "BloodTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PtrNewPatient_HmnBloodType_BloodTypeId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropIndex(
                name: "IX_PtrNewPatient_BloodTypeId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "BloodTypeId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.AddColumn<string>(
                name: "GolonganDarah",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
