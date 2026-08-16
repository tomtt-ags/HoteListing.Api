using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoteListing.Api.Migrations
{
    /// <inheritdoc />
    public partial class codechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Shortname",
                table: "Countries",
                newName: "ShortName");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36aac992-4c8a-4527-9008-98394b071953",
                column: "ConcurrencyStamp",
                value: "e3c4d5e6-a7b8-4c9d-0e1f-2a3b4c5d6e7f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36aac992-72ff-4527-9008-52e7c145ca39",
                column: "ConcurrencyStamp",
                value: "d2b3c4d5-f6a7-4b8c-9d0e-1f2a3b4c5d6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c78e8f15-6a6c-4c8a-b5d1-98394b071953",
                column: "ConcurrencyStamp",
                value: "b1a2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "Countries",
                newName: "Shortname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "BookingId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36aac992-4c8a-4527-9008-98394b071953",
                column: "ConcurrencyStamp",
                value: "4430f3af-e213-42f3-b238-2899e137e809");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36aac992-72ff-4527-9008-52e7c145ca39",
                column: "ConcurrencyStamp",
                value: "226cd362-008a-4c2a-b4f0-19e2a6774921");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c78e8f15-6a6c-4c8a-b5d1-98394b071953",
                column: "ConcurrencyStamp",
                value: "ad081640-a827-4a30-89e1-f34ec55cd676");
        }
    }
}
