using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHiveSpaceKittens.Server.Migrations
{
    /// <inheritdoc />
    public partial class NewEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 1, "Utomhus" });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagName",
                keyValue: "Utomhus");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "Description", "EventDate", "ImageUrl", "Location", "Name", "TicketPrice", "TicketsRemaining" },
                values: new object[] { "A music and arts festival featuring popular and up-and-coming artists, interactive art installations, and food vendors.", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "image 21.jpg", "Indio, California", "Coachella Valley Music and Arts Festival", 399m, 245 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "Description", "EventDate", "ImageUrl", "Location", "Name", "TicketPrice", "TicketsRemaining" },
                values: new object[] { "A film festival showcasing independent films from around the world, with screenings, panel discussions, and special events.", new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sundance.jpg", "Park City, Utah", "Sundance Film Festival", 550m, 85 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Description", "EventDate", "ImageUrl", "Location", "Name", "TicketPrice", "TicketsRemaining" },
                values: new object[,]
                {
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
                    "Outdoor",
                    "Outdoor/Indoor",
                    "Outdoor/Nature"
                });

            migrationBuilder.InsertData(
                table: "EventModelTagModel",
                columns: new[] { "EventsEventId", "TagsTagName" },
                values: new object[,]
                {
                    { 1, "Outdoor/Nature" },
                    { 2, "Indoor" },
                    { 3, "Indoor" },
                    { 4, "Outdoor/Indoor" },
                    { 5, "Outdoor" },
                    { 6, "Outdoor/Nature" },
                    { 7, "Outdoor" },
                    { 8, "Outdoor" },
                    { 9, "Outdoor/Indoor" },
                    { 10, "Outdoor" },
                    { 11, "Outdoor" },
                    { 12, "Indoor" },
                    { 13, "Outdoor" },
                    { 14, "Outdoor" },
                    { 15, "Indoor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 1, "Outdoor/Nature" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 2, "Indoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 3, "Indoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 4, "Outdoor/Indoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 5, "Outdoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 6, "Outdoor/Nature" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 7, "Outdoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 8, "Outdoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 9, "Outdoor/Indoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 10, "Outdoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 11, "Outdoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 12, "Indoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 13, "Outdoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 14, "Outdoor" });

            migrationBuilder.DeleteData(
                table: "EventModelTagModel",
                keyColumns: new[] { "EventsEventId", "TagsTagName" },
                keyValues: new object[] { 15, "Indoor" });

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagName",
                keyValue: "Indoor");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagName",
                keyValue: "Outdoor");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagName",
                keyValue: "Outdoor/Indoor");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagName",
                keyValue: "Outdoor/Nature");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "Description", "EventDate", "ImageUrl", "Location", "Name", "TicketPrice", "TicketsRemaining" },
                values: new object[] { "Fyllefest deluxe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Backyard", "Springbreak", 199m, 10 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "Description", "EventDate", "ImageUrl", "Location", "Name", "TicketPrice", "TicketsRemaining" },
                values: new object[] { "Fyllefest deluxe2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Backyard2", "Springbreak2", 1992m, 102 });

            migrationBuilder.InsertData(
                table: "Tags",
                column: "TagName",
                value: "Utomhus");

            migrationBuilder.InsertData(
                table: "EventModelTagModel",
                columns: new[] { "EventsEventId", "TagsTagName" },
                values: new object[] { 1, "Utomhus" });
        }
    }
}
