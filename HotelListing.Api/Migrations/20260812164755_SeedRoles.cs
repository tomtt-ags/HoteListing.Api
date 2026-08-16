using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoteListing.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36aac992-72ff-4527-9008-52e7c145ca39",
                column: "ConcurrencyStamp",
                value: "934af2d8-94c9-472d-bcda-b44d9e0fccce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c78e8f15-6a6c-4c8a-b5d1-98394b071953",
                column: "ConcurrencyStamp",
                value: "b183f1eb-d393-4ce9-9bf9-07618f8768df");
        }
    }
}
