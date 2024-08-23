using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializeMedicalCheckUpFasilitasAmbulanceOptik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PtrExternalPatientAmbulance",
                schema: "dbo",
                columns: table => new
                {
                    ExternalPatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisBaru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisLama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Komponen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaerahTujuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KelebihanJarak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KelebihanWaktu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paramedis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AntarJemput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Catatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_PtrExternalPatientAmbulance", x => x.ExternalPatientId);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientAmbulance_AdmCity_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "AdmCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientAmbulance_AdmCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "AdmCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientAmbulance_AdmDistrict_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientAmbulance_AdmProvince_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "AdmProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientAmbulance_AdmSubDistrict_SubDistrictId",
                        column: x => x.SubDistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmSubDistrict",
                        principalColumn: "SubDistrictId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PtrExternalPatientFasilitas",
                schema: "dbo",
                columns: table => new
                {
                    ExternalPatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisBaru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisLama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    DetailTindakan = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_PtrExternalPatientFasilitas", x => x.ExternalPatientId);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientFasilitas_AdmCity_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "AdmCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientFasilitas_AdmCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "AdmCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientFasilitas_AdmDistrict_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientFasilitas_AdmProvince_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "AdmProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientFasilitas_AdmSubDistrict_SubDistrictId",
                        column: x => x.SubDistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmSubDistrict",
                        principalColumn: "SubDistrictId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PtrExternalPatientMedicalCheckUp",
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
                    PaketMCU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DokterMCU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipeRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeskripsiRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Promo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuratRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosaAwal = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_PtrExternalPatientMedicalCheckUp", x => x.ExternalPatientId);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientMedicalCheckUp_AdmCity_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "AdmCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientMedicalCheckUp_AdmCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "AdmCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientMedicalCheckUp_AdmDistrict_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientMedicalCheckUp_AdmInsurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "dbo",
                        principalTable: "AdmInsurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientMedicalCheckUp_AdmProvince_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "AdmProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientMedicalCheckUp_AdmSubDistrict_SubDistrictId",
                        column: x => x.SubDistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmSubDistrict",
                        principalColumn: "SubDistrictId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PtrExternalPatientOptik",
                schema: "dbo",
                columns: table => new
                {
                    ExternalPatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisBaru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorRekamMedisLama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipePasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    DetailTindakan = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_PtrExternalPatientOptik", x => x.ExternalPatientId);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientOptik_AdmCity_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "AdmCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientOptik_AdmCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "AdmCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientOptik_AdmDistrict_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientOptik_AdmProvince_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "AdmProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtrExternalPatientOptik_AdmSubDistrict_SubDistrictId",
                        column: x => x.SubDistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmSubDistrict",
                        principalColumn: "SubDistrictId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientAmbulance_CityId",
                schema: "dbo",
                table: "PtrExternalPatientAmbulance",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientAmbulance_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientAmbulance",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientAmbulance_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientAmbulance",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientAmbulance_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientAmbulance",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientAmbulance_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientAmbulance",
                column: "SubDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientFasilitas_CityId",
                schema: "dbo",
                table: "PtrExternalPatientFasilitas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientFasilitas_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientFasilitas",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientFasilitas_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientFasilitas",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientFasilitas_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientFasilitas",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientFasilitas_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientFasilitas",
                column: "SubDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientMedicalCheckUp_CityId",
                schema: "dbo",
                table: "PtrExternalPatientMedicalCheckUp",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientMedicalCheckUp_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientMedicalCheckUp",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientMedicalCheckUp_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientMedicalCheckUp",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientMedicalCheckUp_InsuranceId",
                schema: "dbo",
                table: "PtrExternalPatientMedicalCheckUp",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientMedicalCheckUp_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientMedicalCheckUp",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientMedicalCheckUp_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientMedicalCheckUp",
                column: "SubDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientOptik_CityId",
                schema: "dbo",
                table: "PtrExternalPatientOptik",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientOptik_CountryId",
                schema: "dbo",
                table: "PtrExternalPatientOptik",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientOptik_DistrictId",
                schema: "dbo",
                table: "PtrExternalPatientOptik",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientOptik_ProvinceId",
                schema: "dbo",
                table: "PtrExternalPatientOptik",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PtrExternalPatientOptik_SubDistrictId",
                schema: "dbo",
                table: "PtrExternalPatientOptik",
                column: "SubDistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PtrExternalPatientAmbulance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PtrExternalPatientFasilitas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PtrExternalPatientMedicalCheckUp",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PtrExternalPatientOptik",
                schema: "dbo");
        }
    }
}
