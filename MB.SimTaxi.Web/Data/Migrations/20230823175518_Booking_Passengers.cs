using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.SimTaxi.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Booking_Passengers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingPassenger_Passengers_PassengerId",
                table: "BookingPassenger");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "BookingPassenger",
                newName: "PassengersId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingPassenger_PassengerId",
                table: "BookingPassenger",
                newName: "IX_BookingPassenger_PassengersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPassenger_Passengers_PassengersId",
                table: "BookingPassenger",
                column: "PassengersId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingPassenger_Passengers_PassengersId",
                table: "BookingPassenger");

            migrationBuilder.RenameColumn(
                name: "PassengersId",
                table: "BookingPassenger",
                newName: "PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingPassenger_PassengersId",
                table: "BookingPassenger",
                newName: "IX_BookingPassenger_PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPassenger_Passengers_PassengerId",
                table: "BookingPassenger",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
