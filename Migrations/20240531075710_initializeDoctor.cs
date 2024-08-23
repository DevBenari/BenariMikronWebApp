using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializeDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HmnDoctor",
                schema: "dbo",
                columns: table => new
                {
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeDokter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NamaLengkap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaMarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorKtpDokter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kewarganegaraan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DoctorQueueTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankCabangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAtasNama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankNomorRekening = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Npwp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatRumahLengkap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubDistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KodePos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTelepon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorHandphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatKantorLengkap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTeleponKantor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorIdDokter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JenisKontrak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalAwalKontrak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalAkhirKontrak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalKeluar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuaranteeFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DokterMitra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DokterSpesialis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departemen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_HmnDoctor", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AccBank_BankId",
                        column: x => x.BankId,
                        principalSchema: "dbo",
                        principalTable: "AccBank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AccBankCabang_BankCabangId",
                        column: x => x.BankCabangId,
                        principalSchema: "dbo",
                        principalTable: "AccBankCabang",
                        principalColumn: "BankCabangId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AdmCity_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "AdmCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AdmCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "AdmCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AdmDistrict_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AdmLastEducation_LastEducationId",
                        column: x => x.LastEducationId,
                        principalSchema: "dbo",
                        principalTable: "AdmLastEducation",
                        principalColumn: "LastEducationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AdmProvince_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "AdmProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AdmReligion_ReligionId",
                        column: x => x.ReligionId,
                        principalSchema: "dbo",
                        principalTable: "AdmReligion",
                        principalColumn: "ReligionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AdmSubDistrict_SubDistrictId",
                        column: x => x.SubDistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmSubDistrict",
                        principalColumn: "SubDistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_AdmWorking_WorkingId",
                        column: x => x.WorkingId,
                        principalSchema: "dbo",
                        principalTable: "AdmWorking",
                        principalColumn: "WorkingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_HmnDoctorQueueType_DoctorQueueTypeId",
                        column: x => x.DoctorQueueTypeId,
                        principalSchema: "dbo",
                        principalTable: "HmnDoctorQueueType",
                        principalColumn: "DoctorQueueTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_HmnDoctorTitle_DoctorTitleId",
                        column: x => x.DoctorTitleId,
                        principalSchema: "dbo",
                        principalTable: "HmnDoctorTitle",
                        principalColumn: "DoctorTitleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnDoctor_HmnDoctorType_DoctorTypeId",
                        column: x => x.DoctorTypeId,
                        principalSchema: "dbo",
                        principalTable: "HmnDoctorType",
                        principalColumn: "DoctorTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_BankCabangId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "BankCabangId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_BankId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_CityId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_CountryId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_DistrictId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_DoctorQueueTypeId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "DoctorQueueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_DoctorTitleId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "DoctorTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_DoctorTypeId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "DoctorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_LastEducationId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "LastEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_ProvinceId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_ReligionId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_SubDistrictId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "SubDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_WorkingId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "WorkingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HmnDoctor",
                schema: "dbo");
        }
    }
}
