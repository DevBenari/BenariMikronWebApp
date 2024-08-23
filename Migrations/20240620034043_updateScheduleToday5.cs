using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateScheduleToday5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TanggalPraktek",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "TanggalPraktek",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
