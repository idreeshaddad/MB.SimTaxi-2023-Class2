using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.SimTaxi.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Booking_Test_Paaenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Passengers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Bookings_BookingId",
                table: "Passengers",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Bookings_BookingId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Passengers");
        }
    }
}
