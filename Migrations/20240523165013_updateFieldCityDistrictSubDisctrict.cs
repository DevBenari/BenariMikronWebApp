using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateFieldCityDistrictSubDisctrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "dbo",
                table: "AdmDistrict",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                schema: "dbo",
                table: "AdmDistrict",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "dbo",
                table: "AdmCity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdmSubDistrict_CityId",
                schema: "dbo",
                table: "AdmSubDistrict",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmSubDistrict_CountryId",
                schema: "dbo",
                table: "AdmSubDistrict",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmSubDistrict_ProvinceId",
                schema: "dbo",
                table: "AdmSubDistrict",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmDistrict_CountryId",
                schema: "dbo",
                table: "AdmDistrict",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmDistrict_ProvinceId",
                schema: "dbo",
                table: "AdmDistrict",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmCity_CountryId",
                schema: "dbo",
                table: "AdmCity",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmCity_AdmCountry_CountryId",
                schema: "dbo",
                table: "AdmCity",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "AdmCountry",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmDistrict_AdmCountry_CountryId",
                schema: "dbo",
                table: "AdmDistrict",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "AdmCountry",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmDistrict_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "AdmDistrict",
                column: "ProvinceId",
                principalSchema: "dbo",
                principalTable: "AdmProvince",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmSubDistrict_AdmCity_CityId",
                schema: "dbo",
                table: "AdmSubDistrict",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "AdmCity",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmSubDistrict_AdmCountry_CountryId",
                schema: "dbo",
                table: "AdmSubDistrict",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "AdmCountry",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmSubDistrict_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "AdmSubDistrict",
                column: "ProvinceId",
                principalSchema: "dbo",
                principalTable: "AdmProvince",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmCity_AdmCountry_CountryId",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmDistrict_AdmCountry_CountryId",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmDistrict_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmSubDistrict_AdmCity_CityId",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmSubDistrict_AdmCountry_CountryId",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmSubDistrict_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropIndex(
                name: "IX_AdmSubDistrict_CityId",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropIndex(
                name: "IX_AdmSubDistrict_CountryId",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropIndex(
                name: "IX_AdmSubDistrict_ProvinceId",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropIndex(
                name: "IX_AdmDistrict_CountryId",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropIndex(
                name: "IX_AdmDistrict_ProvinceId",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropIndex(
                name: "IX_AdmCity_CountryId",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "AdmCity");
        }
    }
}
