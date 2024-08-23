using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class changeDeptDoctSelectList2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Department",
                schema: "dbo",
                table: "HmnDoctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                schema: "dbo",
                table: "HmnDoctor");

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
    }
}
