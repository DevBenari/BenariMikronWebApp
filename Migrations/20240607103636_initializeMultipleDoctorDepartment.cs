using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializeMultipleDoctorDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HmnMultipleDoctorDepartment",
                schema: "dbo",
                columns: table => new
                {
                    MultipleDoctorDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DoctorDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_HmnMultipleDoctorDepartment", x => x.MultipleDoctorDepartmentId);
                    table.ForeignKey(
                        name: "FK_HmnMultipleDoctorDepartment_HmnDoctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "dbo",
                        principalTable: "HmnDoctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HmnMultipleDoctorDepartment_HmnDoctorDepartment_DoctorDepartmentId",
                        column: x => x.DoctorDepartmentId,
                        principalSchema: "dbo",
                        principalTable: "HmnDoctorDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HmnMultipleDoctorDepartment_DoctorDepartmentId",
                schema: "dbo",
                table: "HmnMultipleDoctorDepartment",
                column: "DoctorDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HmnMultipleDoctorDepartment_DoctorId",
                schema: "dbo",
                table: "HmnMultipleDoctorDepartment",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HmnMultipleDoctorDepartment",
                schema: "dbo");
        }
    }
}
