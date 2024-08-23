using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializeTipeGelarAntrianDepartmentLokasiPendidikanAgama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HmnDepartmentLocation",
                schema: "dbo",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeLokasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaLokasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_HmnDepartmentLocation", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "HmnDoctorQueueType",
                schema: "dbo",
                columns: table => new
                {
                    DoctorQueueTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeTipeAntrian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaTipeAntrian = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_HmnDoctorQueueType", x => x.DoctorQueueTypeId);
                });

            migrationBuilder.CreateTable(
                name: "HmnDoctorTitle",
                schema: "dbo",
                columns: table => new
                {
                    DoctorTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeGelar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaGelar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LapRL1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LapRL2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_HmnDoctorTitle", x => x.DoctorTitleId);
                });

            migrationBuilder.CreateTable(
                name: "HmnDoctorType",
                schema: "dbo",
                columns: table => new
                {
                    DoctorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeTipeDokter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipeDokter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Persentase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_HmnDoctorType", x => x.DoctorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AdmLastEducation",
                schema: "dbo",
                columns: table => new
                {
                    LastEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodePendidikanTerakhir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPendidikanTerakhir = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_AdmLastEducation", x => x.LastEducationId);
                });

            migrationBuilder.CreateTable(
                name: "AdmReligion",
                schema: "dbo",
                columns: table => new
                {
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeAgama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaAgama = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_AdmReligion", x => x.ReligionId);
                });

            migrationBuilder.CreateTable(
                name: "HmnDoctorDepartment",
                schema: "dbo",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeDepartemen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaDepartemen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Telepon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MulaiJamKerja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelesaiJamKerja = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_HmnDoctorDepartment", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_HmnDoctorDepartment_HmnDepartmentLocation_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "dbo",
                        principalTable: "HmnDepartmentLocation",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctorDepartment_LocationId",
                schema: "dbo",
                table: "HmnDoctorDepartment",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HmnDoctorDepartment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HmnDoctorQueueType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HmnDoctorTitle",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HmnDoctorType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdmLastEducation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdmReligion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HmnDepartmentLocation",
                schema: "dbo");
        }
    }
}
