using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHiveSpaceKittens.Server.Migrations
{
    /// <inheritdoc />
    public partial class FirstSeedEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventTypes",
                column: "TypeName",
                value: "Utomhus");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EventDate", "ExtendedUserId", "ImageUrl", "Location", "Name", "TicketPrice", "TicketsRemaining" },
                values: new object[,]
                {
                    { 1, "Fyllefest deluxe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", "Backyard", "Springbreak", 199m, 10 },
                    { 2, "Fyllefest deluxe2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", "Backyard2", "Springbreak2", 1992m, 102 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "TypeName",
                keyValue: "Utomhus");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
