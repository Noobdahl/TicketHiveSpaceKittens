using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHiveSpaceKittens.Server.Migrations
{
    /// <inheritdoc />
    public partial class booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventModelUserModel",
                columns: new[] { "BookingsEventId", "UsersUserId" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventModelUserModel",
                keyColumns: new[] { "BookingsEventId", "UsersUserId" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
