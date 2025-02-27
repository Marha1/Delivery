using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    /// <inheritdoc />
    public partial class updatemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Cargos_CargoId1",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_CargoId1",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CargoId1",
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
                name: "CargoId1",
                table: "Flights",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CargoId1",
                table: "Flights",
                column: "CargoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Cargos_CargoId1",
                table: "Flights",
                column: "CargoId1",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
