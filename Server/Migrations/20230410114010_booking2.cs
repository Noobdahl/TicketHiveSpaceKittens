using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHiveSpaceKittens.Server.Migrations
{
    /// <inheritdoc />
    public partial class booking2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventModelUserModel",
                columns: new[] { "BookingsEventId", "UsersUserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventModelUserModel",
                keyColumns: new[] { "BookingsEventId", "UsersUserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EventModelUserModel",
                keyColumns: new[] { "BookingsEventId", "UsersUserId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
