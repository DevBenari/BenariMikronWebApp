using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializeScheduleToday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HmnScheduleToday",
                schema: "dbo",
                columns: table => new
                {
                    ScheduleTodayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeJadwal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaDepartemen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hari = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LamaPeriksaPerPasien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagiSore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JamPraktek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ruangan = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_HmnScheduleToday", x => x.ScheduleTodayId);
                    table.ForeignKey(
                        name: "FK_HmnScheduleToday_HmnDoctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "dbo",
                        principalTable: "HmnDoctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HmnScheduleToday_DoctorId",
                schema: "dbo",
                table: "HmnScheduleToday",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HmnScheduleToday",
                schema: "dbo");
        }
    }
}
