using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class initializePtrReferenceDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PtrReferenceDetail",
                schema: "dbo",
                columns: table => new
                {
                    ReferenceDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeDetailRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaDetailRujukan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorTelepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_PtrReferenceDetail", x => x.ReferenceDetailId);
                    table.ForeignKey(
                        name: "FK_PtrReferenceDetail_PtrReferenceType_ReferenceTypeId",
                        column: x => x.ReferenceTypeId,
                        principalSchema: "dbo",
                        principalTable: "PtrReferenceType",
                        principalColumn: "ReferenceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PtrReferenceDetail_ReferenceTypeId",
                schema: "dbo",
                table: "PtrReferenceDetail",
                column: "ReferenceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PtrReferenceDetail",
                schema: "dbo");
        }
    }
}
