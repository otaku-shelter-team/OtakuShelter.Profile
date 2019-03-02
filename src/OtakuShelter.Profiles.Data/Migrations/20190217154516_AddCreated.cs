using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Profiles.Migrations
{
    public partial class AddCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createddatetimeutc",
                table: "profiles",
                newName: "created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created",
                table: "profiles",
                newName: "createddatetimeutc");
        }
    }
}
