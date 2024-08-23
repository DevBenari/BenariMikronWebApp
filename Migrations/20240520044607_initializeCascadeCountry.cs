using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializeCascadeCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdmCountry",
                schema: "dbo",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmCountry", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "AdmProvince",
                schema: "dbo",
                columns: table => new
                {
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmProvince", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK_AdmProvince_AdmCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "AdmCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdmCity",
                schema: "dbo",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmCity", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_AdmCity_AdmProvince_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "AdmProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdmDistrict",
                schema: "dbo",
                columns: table => new
                {
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmDistrict", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_AdmDistrict_AdmCity_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "AdmCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdmSubDistrict",
                schema: "dbo",
                columns: table => new
                {
                    SubDistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmSubDistrict", x => x.SubDistrictId);
                    table.ForeignKey(
                        name: "FK_AdmSubDistrict_AdmDistrict_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "AdmDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmCity_ProvinceId",
                schema: "dbo",
                table: "AdmCity",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmDistrict_CityId",
                schema: "dbo",
                table: "AdmDistrict",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmProvince_CountryId",
                schema: "dbo",
                table: "AdmProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmSubDistrict_DistrictId",
                schema: "dbo",
                table: "AdmSubDistrict",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmSubDistrict",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdmDistrict",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdmCity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdmProvince",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdmCountry",
                schema: "dbo");
        }
    }
}
