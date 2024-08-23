using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateScheduleToday3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NamaDepartemen",
                schema: "dbo",
                table: "HmnScheduleToday",
                newName: "TanggalPraktek");

            migrationBuilder.AlterColumn<string>(
                name: "JamSelesai",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "JamMulai",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HmnScheduleToday_DepartmentId",
                schema: "dbo",
                table: "HmnScheduleToday",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HmnScheduleToday_HmnDoctorDepartment_DepartmentId",
                schema: "dbo",
                table: "HmnScheduleToday",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "HmnDoctorDepartment",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HmnScheduleToday_HmnDoctorDepartment_DepartmentId",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.DropIndex(
                name: "IX_HmnScheduleToday_DepartmentId",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.RenameColumn(
                name: "TanggalPraktek",
                schema: "dbo",
                table: "HmnScheduleToday",
                newName: "NamaDepartemen");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JamSelesai",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JamMulai",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
