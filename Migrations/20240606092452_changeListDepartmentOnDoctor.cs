using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class changeListDepartmentOnDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Department",
                schema: "dbo",
                table: "HmnDoctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
