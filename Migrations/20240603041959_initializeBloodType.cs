using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializeBloodType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmPasienBaru",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdmPenjamin",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "HmnBloodType",
                schema: "dbo",
                columns: table => new
                {
                    BloodTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeGolonganDarah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaGolonganDarah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_HmnBloodType", x => x.BloodTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HmnBloodType",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "AdmPenjamin",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AkhirKerjasama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AkunBankAtasNama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AkunBankKartuKredit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatTagihan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bagian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Direktur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diskon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jabatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JatuhTempo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKerjasama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKontrak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodePenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodePerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodePos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KomisiKartuKredit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KriteriaPembayaran = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenjaminPasienOTC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MulaiKerjasama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaCabang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaKontak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorFax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekeningBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTelepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerusahaanPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pinalti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifGroupPerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermasukPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermasukPenjaminRS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipePerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmPenjamin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdmPasienBaru",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PenjaminId = table.Column<int>(type: "int", nullable: false),
                    AgamaPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatDomisiliPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatKantorPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatKeluargaPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlergiPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagianPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EmailAktifPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenerateQrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GolonganDarahPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HubunganKeluargaPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HubunganPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformasiAlamatPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisKelaminPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KaryawanRumahSakit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KewarganegaraanPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NamaAyahPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaIbuPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaKantorPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaKeluargaTerdekatPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaLengkapPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaPegawaiPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaSutriPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorIdentitasPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorIdentitasSutriPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorPolisPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorRekamMedisBaru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorRekamMedisLama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTeleponKantorPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTeleponKeluargaPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTeleponPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasienPrioritas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PekerjaanAyahPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PekerjaanIbuPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PekerjaanPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PekerjaanSutriPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PendidikanTerakhirPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perusahaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalKelahiranPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempatKelahiranPasien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmPasienBaru", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmPasienBaru_AdmPenjamin_PenjaminId",
                        column: x => x.PenjaminId,
                        principalSchema: "dbo",
                        principalTable: "AdmPenjamin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmPasienBaru_PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru",
                column: "PenjaminId");
        }
    }
}
