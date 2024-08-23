using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kota",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropColumn(
                name: "PerusahaanAsuransi",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.RenameColumn(
                name: "TermasukAsuransiRS",
                schema: "dbo",
                table: "AdmInsurance",
                newName: "TermasukKaryawanRS");

            migrationBuilder.AlterColumn<string>(
                name: "Pinalti",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomorFax",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KomisiKartuKredit",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KodePos",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KodePerusahaan",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Keterangan",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Jabatan",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Diskon",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Bagian",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                schema: "dbo",
                table: "AdmInsurance",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "dbo",
                table: "AdmInsurance",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                schema: "dbo",
                table: "AdmInsurance",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                schema: "dbo",
                table: "AdmInsurance",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubDistrictId",
                schema: "dbo",
                table: "AdmInsurance",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdmInsurance_CityId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmInsurance_CountryId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmInsurance_DistrictId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmInsurance_ProvinceId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmInsurance_SubDistrictId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "SubDistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmInsurance_AdmCity_CityId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "AdmCity",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmInsurance_AdmCountry_CountryId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "AdmCountry",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmInsurance_AdmDistrict_DistrictId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "DistrictId",
                principalSchema: "dbo",
                principalTable: "AdmDistrict",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmInsurance_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "ProvinceId",
                principalSchema: "dbo",
                principalTable: "AdmProvince",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmInsurance_AdmSubDistrict_SubDistrictId",
                schema: "dbo",
                table: "AdmInsurance",
                column: "SubDistrictId",
                principalSchema: "dbo",
                principalTable: "AdmSubDistrict",
                principalColumn: "SubDistrictId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmInsurance_AdmCity_CityId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmInsurance_AdmCountry_CountryId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmInsurance_AdmDistrict_DistrictId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmInsurance_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmInsurance_AdmSubDistrict_SubDistrictId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropIndex(
                name: "IX_AdmInsurance_CityId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropIndex(
                name: "IX_AdmInsurance_CountryId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropIndex(
                name: "IX_AdmInsurance_DistrictId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropIndex(
                name: "IX_AdmInsurance_ProvinceId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropIndex(
                name: "IX_AdmInsurance_SubDistrictId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.DropColumn(
                name: "SubDistrictId",
                schema: "dbo",
                table: "AdmInsurance");

            migrationBuilder.RenameColumn(
                name: "TermasukKaryawanRS",
                schema: "dbo",
                table: "AdmInsurance",
                newName: "TermasukAsuransiRS");

            migrationBuilder.AlterColumn<string>(
                name: "Pinalti",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomorFax",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KomisiKartuKredit",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KodePos",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KodePerusahaan",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Keterangan",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Jabatan",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diskon",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bagian",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kota",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PerusahaanAsuransi",
                schema: "dbo",
                table: "AdmInsurance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
