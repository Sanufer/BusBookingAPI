using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatLayoutJson",
                table: "Buses");

            migrationBuilder.AddColumn<int>(
                name: "AcType",
                table: "Buses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusBrand",
                table: "Buses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcType",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "BusBrand",
                table: "Buses");

            migrationBuilder.AddColumn<string>(
                name: "SeatLayoutJson",
                table: "Buses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
