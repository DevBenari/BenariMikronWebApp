using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class UpdateTambahPasienBaru7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmPasienBaru_AdmPenjamin_PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru");

            migrationBuilder.AlterColumn<int>(
                name: "PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmPasienBaru_AdmPenjamin_PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru",
                column: "PenjaminId",
                principalSchema: "dbo",
                principalTable: "AdmPenjamin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmPasienBaru_AdmPenjamin_PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru");

            migrationBuilder.AlterColumn<int>(
                name: "PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmPasienBaru_AdmPenjamin_PenjaminId",
                schema: "dbo",
                table: "AdmPasienBaru",
                column: "PenjaminId",
                principalSchema: "dbo",
                principalTable: "AdmPenjamin",
                principalColumn: "Id");
        }
    }
}
