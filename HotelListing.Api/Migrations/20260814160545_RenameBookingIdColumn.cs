using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoteListing.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameBookingIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "Id");
        }
    }
}
