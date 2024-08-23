using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateExternalPatientChangeRelationshipCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kecamatan",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "Kelurahan",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "Kota",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "Negara",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "Provinsi",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "Kecamatan",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "Kelurahan",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "Kota",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "Negara",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "Provinsi",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRadiologi_CityId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRadiologi_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRadiologi_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRadiologi_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRadiologi_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "SubDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientLaboratorium_CityId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientLaboratorium_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientLaboratorium_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientLaboratorium_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientLaboratorium_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "SubDistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmCity_CityId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "AdmCity",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmCountry_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "AdmCountry",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmDistrict_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "DistrictId",
                principalSchema: "dbo",
                principalTable: "AdmDistrict",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "ProvinceId",
                principalSchema: "dbo",
                principalTable: "AdmProvince",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmSubDistrict_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "SubDistrictId",
                principalSchema: "dbo",
                principalTable: "AdmSubDistrict",
                principalColumn: "SubDistrictId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmCity_CityId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "AdmCity",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmCountry_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "AdmCountry",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmDistrict_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "DistrictId",
                principalSchema: "dbo",
                principalTable: "AdmDistrict",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "ProvinceId",
                principalSchema: "dbo",
                principalTable: "AdmProvince",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmSubDistrict_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "SubDistrictId",
                principalSchema: "dbo",
                principalTable: "AdmSubDistrict",
                principalColumn: "SubDistrictId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmCity_CityId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmCountry_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmDistrict_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientLaboratorium_AdmSubDistrict_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmCity_CityId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmCountry_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmDistrict_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrExternalPatientRadiologi_AdmSubDistrict_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientRadiologi_CityId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientRadiologi_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientRadiologi_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientRadiologi_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientRadiologi_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientLaboratorium_CityId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientLaboratorium_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientLaboratorium_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientLaboratorium_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropIndex(
                name: "IX_PtrExternalPatientLaboratorium_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi");

            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.AddColumn<string>(
                name: "Kecamatan",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kelurahan",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kota",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Negara",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Provinsi",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kecamatan",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kelurahan",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kota",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
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

            migrationBuilder.AddColumn<string>(
                name: "Provinsi",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
