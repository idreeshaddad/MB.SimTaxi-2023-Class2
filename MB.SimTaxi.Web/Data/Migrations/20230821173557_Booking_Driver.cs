using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.SimTaxi.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Booking_Driver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DriverId",
                table: "Bookings",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Drivers_DriverId",
                table: "Bookings",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Drivers_DriverId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DriverId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Bookings");
        }
    }
}
