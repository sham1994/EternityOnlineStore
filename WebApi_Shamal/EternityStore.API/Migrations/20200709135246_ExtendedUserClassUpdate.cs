using Microsoft.EntityFrameworkCore.Migrations;

namespace EternityStore.API.Migrations
{
    public partial class ExtendedUserClassUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
