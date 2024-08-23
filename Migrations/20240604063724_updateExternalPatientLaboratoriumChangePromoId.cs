using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateExternalPatientLaboratoriumChangePromoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Promo",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.AddColumn<Guid>(
                name: "PromoId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientLaboratorium_PromoId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "PromoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmPromo_PromoId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "PromoId",
                principalSchema: "dbo",
                principalTable: "AdmPromo",
                principalColumn: "PromoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmPromo_PromoId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientLaboratorium_PromoId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "PromoId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.AddColumn<string>(
                name: "Promo",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
