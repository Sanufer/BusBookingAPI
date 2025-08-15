using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRouteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Routes_DestinationCityId",
                table: "Routes",
                column: "DestinationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_SourceCityId",
                table: "Routes",
                column: "SourceCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Cities_DestinationCityId",
                table: "Routes",
                column: "DestinationCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Cities_SourceCityId",
                table: "Routes",
                column: "SourceCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Cities_DestinationCityId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Cities_SourceCityId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_DestinationCityId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_SourceCityId",
                table: "Routes");
        }
    }
}
