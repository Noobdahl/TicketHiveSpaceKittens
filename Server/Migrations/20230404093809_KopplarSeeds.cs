using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHiveSpaceKittens.Server.Migrations
{
    /// <inheritdoc />
    public partial class KopplarSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventModelEventTypesModel",
                columns: new[] { "EventTypesTypeName", "EventsId" },
                values: new object[] { "Utomhus", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventModelEventTypesModel",
                keyColumns: new[] { "EventTypesTypeName", "EventsId" },
                keyValues: new object[] { "Utomhus", 1 });
        }
    }
}
