using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string ManagerRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();
        private string AdminRoleId = Guid.NewGuid().ToString();
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);
            SeedUserRolesSQL(migrationBuilder);

        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
            VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
            VALUES ('{ManagerRoleId}', 'Manager', 'MANAGER', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
            VALUES ('{UserRoleId}', 'User', 'USER', null);");
        }

        private void SeedUserRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
            ([UserId], [RoleId])
        VALUES
            ('5f734880-f3d9-4736-8421-65a66d48020e', '{ManagerRoleId}');

        INSERT INTO [dbo].[AspNetUserRoles]
            ([UserId], [RoleId])
        VALUES
            ('f661cde4-1cfb-4db2-81b9-db030fec9021', '{UserRoleId}');

        INSERT INTO [dbo].[AspNetUserRoles]
            ([UserId], [RoleId])
        VALUES
            ('81b77e15-918e-4467-8edc-046109997e32', '{AdminRoleId}');");
        }        

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
