using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateScheduleToday2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JamPraktek",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.AddColumn<DateTime>(
                name: "JamMulai",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "JamSelesai",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JamMulai",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.DropColumn(
                name: "JamSelesai",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.AddColumn<string>(
                name: "JamPraktek",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
