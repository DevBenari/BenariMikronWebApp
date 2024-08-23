using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateDataInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PtrNewPatient_CrmMasterInsurance_InsuranceId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.AddColumn<Guid>(
                name: "MasterInsuranceInsuranceId",
                schema: "dbo",
                table: "PtrNewPatient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdmInsurance",
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
                    table.PrimaryKey("PK_AdmInsurance", x => x.InsuranceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PtrNewPatient_MasterInsuranceInsuranceId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "MasterInsuranceInsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PtrNewPatient_AdmInsurance_InsuranceId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "InsuranceId",
                principalSchema: "dbo",
                principalTable: "AdmInsurance",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PtrNewPatient_CrmMasterInsurance_MasterInsuranceInsuranceId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "MasterInsuranceInsuranceId",
                principalSchema: "dbo",
                principalTable: "CrmMasterInsurance",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PtrNewPatient_AdmInsurance_InsuranceId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_PtrNewPatient_CrmMasterInsurance_MasterInsuranceInsuranceId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropTable(
                name: "AdmInsurance",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_PtrNewPatient_MasterInsuranceInsuranceId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.DropColumn(
                name: "MasterInsuranceInsuranceId",
                schema: "dbo",
                table: "PtrNewPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_PtrNewPatient_CrmMasterInsurance_InsuranceId",
                schema: "dbo",
                table: "PtrNewPatient",
                column: "InsuranceId",
                principalSchema: "dbo",
                principalTable: "CrmMasterInsurance",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
