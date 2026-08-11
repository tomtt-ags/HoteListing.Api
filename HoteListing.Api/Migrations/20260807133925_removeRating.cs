using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoteListing.Api.Migrations
{
    /// <inheritdoc />
    public partial class removeRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Countries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Countries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
