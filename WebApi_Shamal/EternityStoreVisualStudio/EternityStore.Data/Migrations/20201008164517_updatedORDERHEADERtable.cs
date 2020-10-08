using Microsoft.EntityFrameworkCore.Migrations;

namespace EternityStore.Data.Migrations
{
    public partial class updatedORDERHEADERtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OrderTotal",
                table: "OrderHeaders",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "OrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "OrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "OrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "OrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "OrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "OrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "OrderHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "OrderHeaders");

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderTotal",
                table: "OrderHeaders",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);
        }
    }
}
