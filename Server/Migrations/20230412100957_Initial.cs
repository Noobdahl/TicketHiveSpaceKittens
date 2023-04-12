using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHiveSpaceKittens.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketsRemaining = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagName);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "EventModelTagModel",
                columns: table => new
                {
                    EventsEventId = table.Column<int>(type: "int", nullable: false),
                    TagsTagName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModelTagModel", x => new { x.EventsEventId, x.TagsTagName });
                    table.ForeignKey(
                        name: "FK_EventModelTagModel_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventModelTagModel_Tags_TagsTagName",
                        column: x => x.TagsTagName,
                        principalTable: "Tags",
                        principalColumn: "TagName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventModelUserModel",
                columns: table => new
                {
                    BookingsEventId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModelUserModel", x => new { x.BookingsEventId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_EventModelUserModel_Events_BookingsEventId",
                        column: x => x.BookingsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventModelUserModel_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Description", "EventDate", "ImageUrl", "Location", "Name", "TicketPrice", "TicketsRemaining" },
                values: new object[,]
                {
                    { 1, "A music and arts festival featuring popular and up-and-coming artists, interactive art installations, and food vendors.", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "image 21.jpg", "Indio, California", "Coachella Valley Music and Arts Festival", 399m, 245 },
                    { 2, "A film festival showcasing independent films from around the world, with screenings, panel discussions, and special events.", new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sundance.jpg", "Park City, Utah", "Sundance Film Festival", 550m, 85 },
                    { 3, "A comic book and pop culture convention featuring panels, celebrity appearances, and exhibits.", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ComicCon.jpg", "San Diego, California", "Comic-Con International", 100m, 40 },
                    { 4, "A music festival celebrating the culture and heritage of New Orleans, featuring jazz, blues, and other genres of music, as well as food and crafts vendors.", new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "image 13.jpg", "New Orleans, Louisiana", "New Orleans Jazz & Heritage Festival", 70m, 110 },
                    { 5, "A horse racing event featuring the best thoroughbreds from around the world, as well as fashion and entertainment events.", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "KentuckyDerby.jpg", "Louisville, Kentucky", "Kentucky Derby", 75m, 130 },
                    { 6, "An annual gathering of artists and free spirits, featuring large-scale art installations, live music, and a sense of community.", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burningman.jpg", "Black Rock Desert, Nevada", "Burning Man", 475m, 150 },
                    { 7, "A festival celebrating music, film, and interactive media, with performances, screenings, and panel discussions.", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SXSW.jpg", "Austin, Texas", "South by Southwest (SXSW)", 1475m, 100 },
                    { 8, "A music festival featuring electronic dance music (EDM) acts, carnival rides, and immersive art installations.", new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "image 15.jpg", "Las Vegas, Nevada", "Electric Daisy Carnival (EDC)", 399m, 20 },
                    { 9, "A music festival featuring electronic dance music (EDM) acts, carnival rides, and immersive art installations.", new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "OktoberFest.jpg", "Munich, Germany", "Oktoberfest", 0m, 0 },
                    { 10, "A cycling race through the French countryside, featuring some of the best professional cyclists in the world.", new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "TDF.jpg", "France", "Tour de France", 0m, 0 },
                    { 11, "A golf tournament featuring some of the best professional golfers in the world, played on the historic Augusta National Golf Club course.", new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masters.jpg", "Augusta, Georgia", "The Masters Tournament", 80m, 65 },
                    { 12, "An art exhibition featuring works from contemporary artists from around the world, with installations throughout the city.", new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venice.jpg", "Venice, Italy", "Venice Biennale", 270m, 150 },
                    { 13, "A tennis tournament featuring the world's best players, played on the historic grass courts of the All England Lawn Tennis and Croquet Club.", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wimbledon.jpg", "London, United Kingdom", "Wimbledon Championships", 500m, 250 },
                    { 14, "A music festival featuring electronic dance music (EDM) acts, as well as art installations and other performances.", new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "image 4.jpg", "Miami, Florida", "Ultra Music Festival", 350m, 130 },
                    { 15, "A digital festival featuring esports tournaments, gaming competitions, and other gaming-related activities, as well as live music performances and exhibitors.", new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "image 2.jpg", "Jönköping, Sweden", "DreamHack Summer", 650m, 60 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                column: "TagName",
                values: new object[]
                {
                    "Indoor",
                    "Nature",
                    "Outdoor"
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Country", "Username" },
                values: new object[,]
                {
                    { 1, "Sweden", "user" },
                    { 2, "Sweden", "admin" }
                });

            migrationBuilder.InsertData(
                table: "EventModelTagModel",
                columns: new[] { "EventsEventId", "TagsTagName" },
                values: new object[,]
                {
                    { 1, "Nature" },
                    { 2, "Indoor" },
                    { 3, "Indoor" },
                    { 4, "Indoor" },
                    { 5, "Outdoor" },
                    { 6, "Outdoor" },
                    { 7, "Outdoor" },
                    { 8, "Outdoor" },
                    { 9, "Outdoor" },
                    { 10, "Outdoor" },
                    { 11, "Outdoor" },
                    { 12, "Indoor" },
                    { 13, "Outdoor" },
                    { 14, "Outdoor" },
                    { 15, "Indoor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventModelTagModel_TagsTagName",
                table: "EventModelTagModel",
                column: "TagsTagName");

            migrationBuilder.CreateIndex(
                name: "IX_EventModelUserModel_UsersUserId",
                table: "EventModelUserModel",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventModelTagModel");

            migrationBuilder.DropTable(
                name: "EventModelUserModel");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
