using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updatePatientLaboratoriumAndCreatePatientRadiologi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TempatKelahiran",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "TempatLahir");

            migrationBuilder.RenameColumn(
                name: "TanggalKelahiran",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "TanggalLahir");

            migrationBuilder.RenameColumn(
                name: "PermintaanTestCito",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "Pemeriksaan");

            migrationBuilder.RenameColumn(
                name: "NamaLengkap",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "Provinsi");

            migrationBuilder.RenameColumn(
                name: "Alamat",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "NamaPasien");

            migrationBuilder.AddColumn<string>(
                name: "AlamatLengkap",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
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
                name: "KodePos",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kota",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PtrExternalPatientRadiologi",
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
                    Provinsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodePos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTelepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAktif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipeRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeskripsiRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Promo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuratRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosaAwal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailTindakan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DokterPemeriksa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PtrExternalPatientRadiologi", x => x.ExternalPatientId);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientRadiologi_CrmMasterInsurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "dbo",
                        principalTable: "CrmMasterInsurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientRadiologi_InsuranceId",
                schema: "dbo",
                table: "PtrExternalPatientRadiologi",
                column: "InsuranceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PtrExternalPatientRadiologi",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "AlamatLengkap",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "Kecamatan",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "Kelurahan",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "KodePos",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.DropColumn(
                name: "Kota",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium");

            migrationBuilder.RenameColumn(
                name: "TempatLahir",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "TempatKelahiran");

            migrationBuilder.RenameColumn(
                name: "TanggalLahir",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "TanggalKelahiran");

            migrationBuilder.RenameColumn(
                name: "Provinsi",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "NamaLengkap");

            migrationBuilder.RenameColumn(
                name: "Pemeriksaan",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "PermintaanTestCito");

            migrationBuilder.RenameColumn(
                name: "NamaPasien",
                schema: "dbo",
                table: "PtrExternalPatientLaboratorium",
                newName: "Alamat");
        }
    }
}
