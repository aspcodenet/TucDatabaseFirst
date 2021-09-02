using Microsoft.EntityFrameworkCore.Migrations;

namespace TucDatabaseFirst.Migrations
{
    public partial class Addedregno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegNummer",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegNummer",
                table: "Players");
        }
    }
}
