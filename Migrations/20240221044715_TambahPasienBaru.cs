using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class TambahPasienBaru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "AdmPasienBaru",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomorPasienBaru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisBaru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisLama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPerusahaanPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorPolisPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPegawaiPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BagianPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HubunganPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorIdentitasPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatKelahiranPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalKelahiranPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelaminPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasienPrioritas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgamaPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SukuPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KewarganegaraanPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PendidikanTerakhirPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatDomisiliPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformasiAlamatPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTeleponPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    UploadFoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmPasienBaru", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmPasienBaru",
                schema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
