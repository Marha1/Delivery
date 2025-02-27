using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    /// <inheritdoc />
    public partial class updatemodels3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Cargos_cargoId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_cargoId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "cargoId",
                table: "Flights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Flights",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cargoId",
                table: "Flights",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_cargoId",
                table: "Flights",
                column: "cargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Cargos_cargoId",
                table: "Flights",
                column: "cargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
