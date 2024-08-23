using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class deleteForeignKeyMultipleDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HmnMultipleDoctorDepartment_HmnDoctor_DoctorId",
                schema: "dbo",
                table: "HmnMultipleDoctorDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_HmnMultipleDoctorDepartment_HmnDoctorDepartment_DoctorDepartmentId",
                schema: "dbo",
                table: "HmnMultipleDoctorDepartment");

            migrationBuilder.DropIndex(
                name: "IX_HmnMultipleDoctorDepartment_DoctorDepartmentId",
                schema: "dbo",
                table: "HmnMultipleDoctorDepartment");

            migrationBuilder.DropIndex(
                name: "IX_HmnMultipleDoctorDepartment_DoctorId",
                schema: "dbo",
                table: "HmnMultipleDoctorDepartment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_HmnMultipleDoctorDepartment_HmnDoctor_DoctorId",
                schema: "dbo",
                table: "HmnMultipleDoctorDepartment",
                column: "DoctorId",
                principalSchema: "dbo",
                principalTable: "HmnDoctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HmnMultipleDoctorDepartment_HmnDoctorDepartment_DoctorDepartmentId",
                schema: "dbo",
                table: "HmnMultipleDoctorDepartment",
                column: "DoctorDepartmentId",
                principalSchema: "dbo",
                principalTable: "HmnDoctorDepartment",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
