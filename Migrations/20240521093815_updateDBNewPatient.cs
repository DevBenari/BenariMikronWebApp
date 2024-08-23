using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateDBNewPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TempatKelahiranPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "TipePasien");

            migrationBuilder.RenameColumn(
                name: "TanggalKelahiranPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "TempatLahir");

            migrationBuilder.RenameColumn(
                name: "PendidikanTerakhirPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "TanggalLahir");

            migrationBuilder.RenameColumn(
                name: "PekerjaanPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "Pekerjaan");

            migrationBuilder.RenameColumn(
                name: "NomorTeleponPasien2",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NomorTeleponKantor");

            migrationBuilder.RenameColumn(
                name: "NomorTeleponPasien1",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "PendidikanTerakhir");

            migrationBuilder.RenameColumn(
                name: "NomorTeleponKantorPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NomorTelepon2");

            migrationBuilder.RenameColumn(
                name: "NamaKeluargaTerdekatPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NomorTelepon1");

            migrationBuilder.RenameColumn(
                name: "NamaKantorPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NamaKantor");

            migrationBuilder.RenameColumn(
                name: "KewarganegaraanPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NamaKeluargaTerdekat");

            migrationBuilder.RenameColumn(
                name: "JenisKelaminPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "Kewarganegaraan");

            migrationBuilder.RenameColumn(
                name: "InformasiAlamatPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "JenisKelamin");

            migrationBuilder.RenameColumn(
                name: "HubunganKeluargaPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "HubunganKeluarga");

            migrationBuilder.RenameColumn(
                name: "GolonganDarahPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "GolonganDarah");

            migrationBuilder.RenameColumn(
                name: "EmailAktifPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "AlergiPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "Alergi");

            migrationBuilder.RenameColumn(
                name: "AlamatKantorPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "KodePos");

            migrationBuilder.RenameColumn(
                name: "AlamatDomisiliPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "AlamatLengkap");

            migrationBuilder.RenameColumn(
                name: "AgamaPasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "Agama");

            migrationBuilder.AddColumn<string>(
                name: "AlamatKantor",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubDistrictId",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PtrNewPatient_CityId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrNewPatient_CountryId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrNewPatient_DistrictId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrNewPatient_ProvinceId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrNewPatient_SubDistrictId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "SubDistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_PtrNewPatient_AdmCity_CityId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "AdmCity",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrNewPatient_AdmCountry_CountryId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "AdmCountry",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrNewPatient_AdmDistrict_DistrictId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "DistrictId",
                principalSchema: "dbo",
                principalTable: "AdmDistrict",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrNewPatient_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "ProvinceId",
                principalSchema: "dbo",
                principalTable: "AdmProvince",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrNewPatient_AdmSubDistrict_SubDistrictId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "SubDistrictId",
                principalSchema: "dbo",
                principalTable: "AdmSubDistrict",
                principalColumn: "SubDistrictId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PtrNewPatient_AdmCity_CityId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrNewPatient_AdmCountry_CountryId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrNewPatient_AdmDistrict_DistrictId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrNewPatient_AdmProvince_ProvinceId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrNewPatient_AdmSubDistrict_SubDistrictId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropIndex(
                name: "IX_PtrNewPatient_CityId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropIndex(
                name: "IX_PtrNewPatient_CountryId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropIndex(
                name: "IX_PtrNewPatient_DistrictId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropIndex(
                name: "IX_PtrNewPatient_ProvinceId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropIndex(
                name: "IX_PtrNewPatient_SubDistrictId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "AlamatKantor",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "SubDistrictId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.RenameColumn(
                name: "TipePasien",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "TempatKelahiranPasien");

            migrationBuilder.RenameColumn(
                name: "TempatLahir",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "TanggalKelahiranPasien");

            migrationBuilder.RenameColumn(
                name: "TanggalLahir",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "PendidikanTerakhirPasien");

            migrationBuilder.RenameColumn(
                name: "PendidikanTerakhir",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NomorTeleponPasien1");

            migrationBuilder.RenameColumn(
                name: "Pekerjaan",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "PekerjaanPasien");

            migrationBuilder.RenameColumn(
                name: "NomorTeleponKantor",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NomorTeleponPasien2");

            migrationBuilder.RenameColumn(
                name: "NomorTelepon2",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NomorTeleponKantorPasien");

            migrationBuilder.RenameColumn(
                name: "NomorTelepon1",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NamaKeluargaTerdekatPasien");

            migrationBuilder.RenameColumn(
                name: "NamaKeluargaTerdekat",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "KewarganegaraanPasien");

            migrationBuilder.RenameColumn(
                name: "NamaKantor",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "NamaKantorPasien");

            migrationBuilder.RenameColumn(
                name: "KodePos",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "AlamatKantorPasien");

            migrationBuilder.RenameColumn(
                name: "Kewarganegaraan",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "JenisKelaminPasien");

            migrationBuilder.RenameColumn(
                name: "JenisKelamin",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "InformasiAlamatPasien");

            migrationBuilder.RenameColumn(
                name: "HubunganKeluarga",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "HubunganKeluargaPasien");

            migrationBuilder.RenameColumn(
                name: "GolonganDarah",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "GolonganDarahPasien");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "EmailAktifPasien");

            migrationBuilder.RenameColumn(
                name: "Alergi",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "AlergiPasien");

            migrationBuilder.RenameColumn(
                name: "AlamatLengkap",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "AlamatDomisiliPasien");

            migrationBuilder.RenameColumn(
                name: "Agama",
                schema: "dbo",
                table: "PtrNewPatient",
                newName: "AgamaPasien");
        }
    }
}
