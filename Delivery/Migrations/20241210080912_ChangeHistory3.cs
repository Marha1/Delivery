using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    /// <inheritdoc />
    public partial class ChangeHistory3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryOfFlights_Flights_FlightId",
                table: "HistoryOfFlights");

            migrationBuilder.DropIndex(
                name: "IX_HistoryOfFlights_FlightId",
                table: "HistoryOfFlights");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "HistoryOfFlights",
                newName: "type");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "HistoryOfFlights",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DispatchDate",
                table: "HistoryOfFlights",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EndPoint",
                table: "HistoryOfFlights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlightName",
                table: "HistoryOfFlights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartingPoint",
                table: "HistoryOfFlights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "HistoryOfFlights",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "HistoryOfFlights",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "HistoryOfFlights");

            migrationBuilder.DropColumn(
                name: "DispatchDate",
                table: "HistoryOfFlights");

            migrationBuilder.DropColumn(
                name: "EndPoint",
                table: "HistoryOfFlights");

            migrationBuilder.DropColumn(
                name: "FlightName",
                table: "HistoryOfFlights");

            migrationBuilder.DropColumn(
                name: "StartingPoint",
                table: "HistoryOfFlights");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "HistoryOfFlights");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "HistoryOfFlights");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "HistoryOfFlights",
                newName: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfFlights_FlightId",
                table: "HistoryOfFlights",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryOfFlights_Flights_FlightId",
                table: "HistoryOfFlights",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
