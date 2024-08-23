using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializeExternalPatientLaboratorium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PtrExternalPatientLaboratorium",
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
                    NamaLengkap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorIdentitasPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatKelahiran = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalKelahiran = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTelepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAktif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipeRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeskripsiRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Promo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipePemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuratRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosaAwal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalSampling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailTindakan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DokterPemeriksa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermintaanTestCito = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PtrExternalPatientLaboratorium", x => x.ExternalPatientId);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientLaboratorium_CrmMasterInsurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "dbo",
                        principalTable: "CrmMasterInsurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientLaboratorium_InsuranceId",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                column: "InsuranceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PtrExternalPatientLaboratorium",
                schema: "dbo");
        }
    }
}
