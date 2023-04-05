using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHiveSpaceKittens.Server.Migrations
{
    /// <inheritdoc />
    public partial class FirstSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Description", "EventDate", "ImageUrl", "Location", "Name", "TicketPrice", "TicketsRemaining" },
                values: new object[,]
                {
                    { 1, "Fyllefest deluxe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Backyard", "Springbreak", 199m, 10 },
                    { 2, "Fyllefest deluxe2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Backyard2", "Springbreak2", 1992m, 102 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                column: "TagName",
                value: "Utomhus");

            migrationBuilder.InsertData(
                table: "EventModelTagModel",
                columns: new[] { "EventsEventId", "TagsTagName" },
                values: new object[] { 1, "Utomhus" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 1, "Utomhus" });

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagName",
                keyValue: "Utomhus");
        }
    }
}
