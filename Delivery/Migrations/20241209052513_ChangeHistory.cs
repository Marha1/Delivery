using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    /// <inheritdoc />
    public partial class ChangeHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryOfFlights_Drivers_DriverId",
                table: "HistoryOfFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryOfFlights_Flights_FlightId",
                table: "HistoryOfFlights");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_FlightId",
                table: "Cargos");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_FlightId",
                table: "Cargos",
                column: "FlightId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryOfFlights_Drivers_DriverId",
                table: "HistoryOfFlights",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryOfFlights_Flights_FlightId",
                table: "HistoryOfFlights",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryOfFlights_Drivers_DriverId",
                table: "HistoryOfFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryOfFlights_Flights_FlightId",
                table: "HistoryOfFlights");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_FlightId",
                table: "Cargos");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_FlightId",
                table: "Cargos",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryOfFlights_Drivers_DriverId",
                table: "HistoryOfFlights",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryOfFlights_Flights_FlightId",
                table: "HistoryOfFlights",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
