using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializeReferenceTipeDetailReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PtrReference",
                schema: "dbo",
                columns: table => new
                {
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PtrReference", x => x.ReferenceId);
                });

            migrationBuilder.CreateTable(
                name: "PtrReferenceType",
                schema: "dbo",
                columns: table => new
                {
                    ReferenceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeTipeRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaTipeRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PtrReferenceType", x => x.ReferenceTypeId);
                    table.ForeignKey(
                        name: "FK_PtrReferenceType_PtrReference_ReferenceId",
                        column: x => x.ReferenceId,
                        principalSchema: "dbo",
                        principalTable: "PtrReference",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PtrReferenceType_ReferenceId",
                schema: "dbo",
                table: "PtrReferenceType",
                column: "ReferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PtrReferenceType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PtrReference",
                schema: "dbo");
        }
    }
}
