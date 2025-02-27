using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    /// <inheritdoc />
    public partial class chang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Operators_AuthId",
                table: "Operators");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_AuthId",
                table: "Drivers");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_AuthId",
                table: "Operators",
                column: "AuthId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_AuthId",
                table: "Drivers",
                column: "AuthId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Operators_AuthId",
                table: "Operators");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_AuthId",
                table: "Drivers");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_AuthId",
                table: "Operators",
                column: "AuthId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_AuthId",
                table: "Drivers",
                column: "AuthId");
        }
    }
}
