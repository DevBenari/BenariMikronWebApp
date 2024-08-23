using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class updateCascadeCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "AdmSubDistrict",
                newName: "NamaKelurahan");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "AdmProvince",
                newName: "NamaProvinsi");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "AdmDistrict",
                newName: "NamaKecamatan");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "AdmCountry",
                newName: "NamaNegara");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "AdmCity",
                newName: "NamaKota");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KodeKelurahan",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmSubDistrict",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmProvince",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmProvince",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmProvince",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmProvince",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmProvince",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KodeProvinsi",
                schema: "dbo",
                table: "AdmProvince",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmProvince",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmProvince",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmDistrict",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmDistrict",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmDistrict",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmDistrict",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmDistrict",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KodeKecamatan",
                schema: "dbo",
                table: "AdmDistrict",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmDistrict",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmDistrict",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmCountry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmCountry",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmCountry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmCountry",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmCountry",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KodeNegara",
                schema: "dbo",
                table: "AdmCountry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmCountry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmCountry",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmCity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmCity",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmCity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmCity",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmCity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KodeKota",
                schema: "dbo",
                table: "AdmCity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmCity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmCity",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "KodeKelurahan",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmSubDistrict");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmProvince");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmProvince");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmProvince");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmProvince");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmProvince");

            migrationBuilder.DropColumn(
                name: "KodeProvinsi",
                schema: "dbo",
                table: "AdmProvince");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmProvince");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmProvince");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "KodeKecamatan",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmDistrict");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmCountry");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmCountry");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmCountry");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmCountry");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmCountry");

            migrationBuilder.DropColumn(
                name: "KodeNegara",
                schema: "dbo",
                table: "AdmCountry");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmCountry");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmCountry");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.DropColumn(
                name: "KodeKota",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "AdmCity");

            migrationBuilder.RenameColumn(
                name: "NamaKelurahan",
                schema: "dbo",
                table: "AdmSubDistrict",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NamaProvinsi",
                schema: "dbo",
                table: "AdmProvince",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NamaKecamatan",
                schema: "dbo",
                table: "AdmDistrict",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NamaNegara",
                schema: "dbo",
                table: "AdmCountry",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NamaKota",
                schema: "dbo",
                table: "AdmCity",
                newName: "Name");
        }
    }
}
