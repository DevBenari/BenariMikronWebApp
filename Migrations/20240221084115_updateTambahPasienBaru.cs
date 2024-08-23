using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateTambahPasienBaru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDate",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "GenerateQrCode",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyBy",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifyDate",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "datetimeoffset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmPasienBaru");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "AdmPasienBaru");

            migrationBuilder.DropColumn(
                name: "GenerateQrCode",
                schema: "dbo",
                table: "AdmPasienBaru");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                schema: "dbo",
                table: "AdmPasienBaru");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                schema: "dbo",
                table: "AdmPasienBaru");
        }
    }
}
