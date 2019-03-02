using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Profiles.Migrations
{
    public partial class SnakeCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "accountid",
                table: "profiles",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "UQ_accountid",
                table: "profiles",
                newName: "UQ_account_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "profiles",
                newName: "accountid");

            migrationBuilder.RenameIndex(
                name: "UQ_account_id",
                table: "profiles",
                newName: "UQ_accountid");
        }
    }
}
