using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class TambahPenjamin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomorPasienBaru",
                schema: "dbo",
                table: "AdmPasienBaru",
                newName: "KodePasien");

            migrationBuilder.AlterColumn<string>(
                name: "NomorRekamMedisLama",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdmPenjamin",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodePenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    TermasukPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermasukPenjaminRS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerusahaanPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmPenjamin", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmPasienBaru_PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru",
                column: "PenjaminId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmPasienBaru_AdmPenjamin_PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru",
                column: "PenjaminId",
                principalSchema: "dbo",
                principalTable: "AdmPenjamin",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmPasienBaru_AdmPenjamin_PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru");

            migrationBuilder.DropTable(
                name: "AdmPenjamin",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_AdmPasienBaru_PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru");

            migrationBuilder.DropColumn(
                name: "PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru");

            migrationBuilder.RenameColumn(
                name: "KodePasien",
                schema: "dbo",
                table: "AdmPasienBaru",
                newName: "NomorPasienBaru");

            migrationBuilder.AlterColumn<string>(
                name: "NomorRekamMedisLama",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
