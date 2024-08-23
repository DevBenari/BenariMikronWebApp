using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializePatientExternalRehabilitasiMedik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PtrExternalPatientRehabilitasiMedik",
                schema: "dbo",
                columns: table => new
                {
                    ExternalPatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisBaru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisLama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomorPolis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorIdentitasPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatLengkap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubDistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KodePos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTelepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAktif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipeRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeskripsiRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuratRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosaAwal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaftarTindakan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DokterPemeriksa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenerateQrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PtrExternalPatientRehabilitasiMedik", x => x.ExternalPatientId);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientRehabilitasiMedik_AdmCity_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "AdmCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientRehabilitasiMedik_AdmCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "AdmCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientRehabilitasiMedik_AdmDistrict_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientRehabilitasiMedik_AdmInsurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "dbo",
                        principalTable: "AdmInsurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientRehabilitasiMedik_AdmProvince_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "AdmProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientRehabilitasiMedik_AdmSubDistrict_SubDistrictId",
                        column: x => x.SubDistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmSubDistrict",
                        principalColumn: "SubDistrictId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRehabilitasiMedik_CityId",
                schema: "dbo",
                table: "PtrExternalPatientRehabilitasiMedik",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRehabilitasiMedik_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientRehabilitasiMedik",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRehabilitasiMedik_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRehabilitasiMedik",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRehabilitasiMedik_InsuranceId",
                schema: "dbo",
                table: "PtrExternalPatientRehabilitasiMedik",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRehabilitasiMedik_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientRehabilitasiMedik",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRehabilitasiMedik_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientRehabilitasiMedik",
                column: "SubDistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PtrExternalPatientRehabilitasiMedik",
                schema: "dbo");
        }
    }
}
