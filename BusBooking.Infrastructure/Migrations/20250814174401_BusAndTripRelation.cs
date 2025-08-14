using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BusAndTripRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_BusOperators_BusOperatorId",
                table: "Buses");

            migrationBuilder.DropIndex(
                name: "IX_Buses_BusOperatorId",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "BusOperatorId",
                table: "Buses");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_OperatorId",
                table: "Buses",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_BusOperators_OperatorId",
                table: "Buses",
                column: "OperatorId",
                principalTable: "BusOperators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Buses_BusId",
                table: "Trips",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_BusOperators_OperatorId",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Buses_BusId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_BusId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Buses_OperatorId",
                table: "Buses");

            migrationBuilder.AddColumn<Guid>(
                name: "BusOperatorId",
                table: "Buses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusOperatorId",
                table: "Buses",
                column: "BusOperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_BusOperators_BusOperatorId",
                table: "Buses",
                column: "BusOperatorId",
                principalTable: "BusOperators",
                principalColumn: "Id");
        }
    }
}
