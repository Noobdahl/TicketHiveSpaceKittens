using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHiveSpaceKittens.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ApplicationUser_ExtendedUserId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_Events_ExtendedUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ExtendedUserId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "EventViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketsRemaining = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Tickets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_EventViewModel_EventId",
                        column: x => x.EventId,
                        principalTable: "EventViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTypesViewModel",
                columns: table => new
                {
                    TypeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypesViewModel", x => x.TypeName);
                    table.ForeignKey(
                        name: "FK_EventTypesViewModel_EventViewModel_EventViewModelId",
                        column: x => x.EventViewModelId,
                        principalTable: "EventViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EventId",
                table: "Bookings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypesViewModel_EventViewModelId",
                table: "EventTypesViewModel",
                column: "EventViewModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "EventTypesViewModel");

            migrationBuilder.DropTable(
                name: "EventViewModel");

            migrationBuilder.AddColumn<string>(
                name: "ExtendedUserId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    EventModelId = table.Column<int>(type: "int", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Events_EventModelId",
                        column: x => x.EventModelId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtendedUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtendedUserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ExtendedUserId",
                table: "Events",
                column: "ExtendedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_EventModelId",
                table: "ApplicationUser",
                column: "EventModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ApplicationUser_ExtendedUserId",
                table: "Events",
                column: "ExtendedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }
    }
}
