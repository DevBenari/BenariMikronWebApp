using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateScheduleToday1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hari",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.AddColumn<Guid>(
                name: "DayId",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HmnScheduleToday_DayId",
                schema: "dbo",
                table: "HmnScheduleToday",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_HmnScheduleToday_HmnDay_DayId",
                schema: "dbo",
                table: "HmnScheduleToday",
                column: "DayId",
                principalSchema: "dbo",
                principalTable: "HmnDay",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HmnScheduleToday_HmnDay_DayId",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.DropIndex(
                name: "IX_HmnScheduleToday_DayId",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.DropColumn(
                name: "DayId",
                schema: "dbo",
                table: "HmnScheduleToday");

            migrationBuilder.AddColumn<string>(
                name: "Hari",
                schema: "dbo",
                table: "HmnScheduleToday",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
