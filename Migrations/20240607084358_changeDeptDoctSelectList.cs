using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class changeDeptDoctSelectList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HmnDoctorDepartment_HmnDoctor_DoctorId",
                schema: "dbo",
                table: "HmnDoctorDepartment");

            migrationBuilder.DropIndex(
                name: "IX_HmnDoctorDepartment_DoctorId",
                schema: "dbo",
                table: "HmnDoctorDepartment");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                schema: "dbo",
                table: "HmnDoctorDepartment");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                schema: "dbo",
                table: "HmnDoctor",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctor_DepartmentId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HmnDoctor_HmnDoctorDepartment_DepartmentId",
                schema: "dbo",
                table: "HmnDoctor",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "HmnDoctorDepartment",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HmnDoctor_HmnDoctorDepartment_DepartmentId",
                schema: "dbo",
                table: "HmnDoctor");

            migrationBuilder.DropIndex(
                name: "IX_HmnDoctor_DepartmentId",
                schema: "dbo",
                table: "HmnDoctor");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "dbo",
                table: "HmnDoctor");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                schema: "dbo",
                table: "HmnDoctorDepartment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HmnDoctorDepartment_DoctorId",
                schema: "dbo",
                table: "HmnDoctorDepartment",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_HmnDoctorDepartment_HmnDoctor_DoctorId",
                schema: "dbo",
                table: "HmnDoctorDepartment",
                column: "DoctorId",
                principalSchema: "dbo",
                principalTable: "HmnDoctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
