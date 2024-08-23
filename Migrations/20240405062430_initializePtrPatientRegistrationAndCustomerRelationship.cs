using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializePtrPatientRegistrationAndCustomerRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrmMasterInsurance",
                schema: "dbo",
                columns: table => new
                {
                    InsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeAsuransi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MulaiKerjasama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AkhirKerjasama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodePerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipePerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifGroupPerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AkunBankKartuKredit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direktur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaKontak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jabatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bagian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KomisiKartuKredit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diskon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermasukAsuransi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermasukAsuransiRS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerusahaanAsuransi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatTagihan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodePos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTelepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorFax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKerjasama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKontrak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JatuhTempo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KriteriaPembayaran = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenjaminPasienOTC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AkunBankAtasNama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaCabang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekeningBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pinalti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_CrmMasterInsurance", x => x.InsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "PtrNewPatient",
                schema: "dbo",
                columns: table => new
                {
                    PatientRegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisBaru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisLama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomorPolis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaLengkapPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorIdentitasPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatKelahiranPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalKelahiranPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelaminPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasienPrioritas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgamaPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KewarganegaraanPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PendidikanTerakhirPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatDomisiliPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformasiAlamatPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTeleponPasien1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTeleponPasien2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAktifPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PekerjaanPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaKantorPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatKantorPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTeleponKantorPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GolonganDarahPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlergiPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaKeluargaTerdekatPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HubunganKeluargaPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KaryawanRumahSakit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatKeluargaPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTeleponKeluargaPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaAyahPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PekerjaanAyahPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaIbuPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PekerjaanIbuPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaSutriPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PekerjaanSutriPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorIdentitasSutriPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_PtrNewPatient", x => x.PatientRegistrationId);
                    table.ForeignKey(
                        name: "FK_PtrNewPatient_CrmMasterInsurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "dbo",
                        principalTable: "CrmMasterInsurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PtrNewPatient_InsuranceId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "InsuranceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PtrNewPatient",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CrmMasterInsurance",
                schema: "dbo");
        }
    }
}
