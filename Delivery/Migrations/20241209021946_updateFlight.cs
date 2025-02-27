using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    /// <inheritdoc />
    public partial class updateFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndPoint",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartingPoint",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndPoint",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "StartingPoint",
                table: "Flights");
        }
    }
}
