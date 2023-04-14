﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketHiveSpaceKittens.Server.Data;

#nullable disable

namespace TicketHiveSpaceKittens.Server.Migrations
{
    [DbContext(typeof(EventDbContext))]
    [Migration("20230413235422_InitialTorsdag")]
    partial class InitialTorsdag
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventModelTagModel", b =>
                {
                    b.Property<int>("EventsEventId")
                        .HasColumnType("int");

                    b.Property<string>("TagsTagName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EventsEventId", "TagsTagName");

                    b.HasIndex("TagsTagName");

                    b.ToTable("EventModelTagModel");

                    b.HasData(
                        new
                        {
                            EventsEventId = 1,
                            TagsTagName = "Nature"
                        },
                        new
                        {
                            EventsEventId = 2,
                            TagsTagName = "Indoor"
                        },
                        new
                        {
                            EventsEventId = 3,
                            TagsTagName = "Indoor"
                        },
                        new
                        {
                            EventsEventId = 4,
                            TagsTagName = "Indoor"
                        },
                        new
                        {
                            EventsEventId = 5,
                            TagsTagName = "Outdoor"
                        },
                        new
                        {
                            EventsEventId = 6,
                            TagsTagName = "Outdoor"
                        },
                        new
                        {
                            EventsEventId = 7,
                            TagsTagName = "Outdoor"
                        },
                        new
                        {
                            EventsEventId = 8,
                            TagsTagName = "Outdoor"
                        },
                        new
                        {
                            EventsEventId = 9,
                            TagsTagName = "Outdoor"
                        },
                        new
                        {
                            EventsEventId = 10,
                            TagsTagName = "Outdoor"
                        },
                        new
                        {
                            EventsEventId = 11,
                            TagsTagName = "Outdoor"
                        },
                        new
                        {
                            EventsEventId = 12,
                            TagsTagName = "Indoor"
                        },
                        new
                        {
                            EventsEventId = 13,
                            TagsTagName = "Outdoor"
                        },
                        new
                        {
                            EventsEventId = 14,
                            TagsTagName = "Outdoor"
                        },
                        new
                        {
                            EventsEventId = 15,
                            TagsTagName = "Indoor"
                        });
                });

            modelBuilder.Entity("EventModelUserModel", b =>
                {
                    b.Property<int>("BookingsEventId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("BookingsEventId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("EventModelUserModel");
                });

            modelBuilder.Entity("TicketHiveSpaceKittens.Shared.Models.EventModel", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TicketsRemaining")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Description = "A music and arts festival featuring popular and up-and-coming artists, interactive art installations, and food vendors.",
                            EventDate = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "image 21.jpg",
                            Location = "Indio, California",
                            Name = "Coachella Valley Music and Arts Festival",
                            TicketPrice = 399m,
                            TicketsRemaining = 245
                        },
                        new
                        {
                            EventId = 2,
                            Description = "A film festival showcasing independent films from around the world, with screenings, panel discussions, and special events.",
                            EventDate = new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "Sundance.jpg",
                            Location = "Park City, Utah",
                            Name = "Sundance Film Festival",
                            TicketPrice = 550m,
                            TicketsRemaining = 85
                        },
                        new
                        {
                            EventId = 3,
                            Description = "A comic book and pop culture convention featuring panels, celebrity appearances, and exhibits.",
                            EventDate = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "ComicCon.jpg",
                            Location = "San Diego, California",
                            Name = "Comic-Con International",
                            TicketPrice = 100m,
                            TicketsRemaining = 40
                        },
                        new
                        {
                            EventId = 4,
                            Description = "A music festival celebrating the culture and heritage of New Orleans, featuring jazz, blues, and other genres of music, as well as food and crafts vendors.",
                            EventDate = new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "image 13.jpg",
                            Location = "New Orleans, Louisiana",
                            Name = "New Orleans Jazz & Heritage Festival",
                            TicketPrice = 70m,
                            TicketsRemaining = 110
                        },
                        new
                        {
                            EventId = 5,
                            Description = "A horse racing event featuring the best thoroughbreds from around the world, as well as fashion and entertainment events.",
                            EventDate = new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "KentuckyDerby.jpg",
                            Location = "Louisville, Kentucky",
                            Name = "Kentucky Derby",
                            TicketPrice = 75m,
                            TicketsRemaining = 130
                        },
                        new
                        {
                            EventId = 6,
                            Description = "An annual gathering of artists and free spirits, featuring large-scale art installations, live music, and a sense of community.",
                            EventDate = new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "Burningman.jpg",
                            Location = "Black Rock Desert, Nevada",
                            Name = "Burning Man",
                            TicketPrice = 475m,
                            TicketsRemaining = 150
                        },
                        new
                        {
                            EventId = 7,
                            Description = "A festival celebrating music, film, and interactive media, with performances, screenings, and panel discussions.",
                            EventDate = new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "SXSW.jpg",
                            Location = "Austin, Texas",
                            Name = "South by Southwest (SXSW)",
                            TicketPrice = 1475m,
                            TicketsRemaining = 100
                        },
                        new
                        {
                            EventId = 8,
                            Description = "A music festival featuring electronic dance music (EDM) acts, carnival rides, and immersive art installations.",
                            EventDate = new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "image 15.jpg",
                            Location = "Las Vegas, Nevada",
                            Name = "Electric Daisy Carnival (EDC)",
                            TicketPrice = 399m,
                            TicketsRemaining = 20
                        },
                        new
                        {
                            EventId = 9,
                            Description = "A music festival featuring electronic dance music (EDM) acts, carnival rides, and immersive art installations.",
                            EventDate = new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "OktoberFest.jpg",
                            Location = "Munich, Germany",
                            Name = "Oktoberfest",
                            TicketPrice = 0m,
                            TicketsRemaining = 0
                        },
                        new
                        {
                            EventId = 10,
                            Description = "A cycling race through the French countryside, featuring some of the best professional cyclists in the world.",
                            EventDate = new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "TDF.jpg",
                            Location = "France",
                            Name = "Tour de France",
                            TicketPrice = 0m,
                            TicketsRemaining = 0
                        },
                        new
                        {
                            EventId = 11,
                            Description = "A golf tournament featuring some of the best professional golfers in the world, played on the historic Augusta National Golf Club course.",
                            EventDate = new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "Masters.jpg",
                            Location = "Augusta, Georgia",
                            Name = "The Masters Tournament",
                            TicketPrice = 80m,
                            TicketsRemaining = 65
                        },
                        new
                        {
                            EventId = 12,
                            Description = "An art exhibition featuring works from contemporary artists from around the world, with installations throughout the city.",
                            EventDate = new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "Venice.jpg",
                            Location = "Venice, Italy",
                            Name = "Venice Biennale",
                            TicketPrice = 270m,
                            TicketsRemaining = 150
                        },
                        new
                        {
                            EventId = 13,
                            Description = "A tennis tournament featuring the world's best players, played on the historic grass courts of the All England Lawn Tennis and Croquet Club.",
                            EventDate = new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "Wimbledon.jpg",
                            Location = "London, United Kingdom",
                            Name = "Wimbledon Championships",
                            TicketPrice = 500m,
                            TicketsRemaining = 250
                        },
                        new
                        {
                            EventId = 14,
                            Description = "A music festival featuring electronic dance music (EDM) acts, as well as art installations and other performances.",
                            EventDate = new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "image 4.jpg",
                            Location = "Miami, Florida",
                            Name = "Ultra Music Festival",
                            TicketPrice = 350m,
                            TicketsRemaining = 130
                        },
                        new
                        {
                            EventId = 15,
                            Description = "A digital festival featuring esports tournaments, gaming competitions, and other gaming-related activities, as well as live music performances and exhibitors.",
                            EventDate = new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "image 2.jpg",
                            Location = "Jönköping, Sweden",
                            Name = "DreamHack Summer",
                            TicketPrice = 650m,
                            TicketsRemaining = 60
                        });
                });

            modelBuilder.Entity("TicketHiveSpaceKittens.Shared.Models.TagModel", b =>
                {
                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TagName");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagName = "Outdoor"
                        },
                        new
                        {
                            TagName = "Nature"
                        },
                        new
                        {
                            TagName = "Indoor"
                        });
                });

            modelBuilder.Entity("TicketHiveSpaceKittens.Shared.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Country = "Sweden",
                            Username = "user"
                        },
                        new
                        {
                            UserId = 2,
                            Country = "Sweden",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("EventModelTagModel", b =>
                {
                    b.HasOne("TicketHiveSpaceKittens.Shared.Models.EventModel", null)
                        .WithMany()
                        .HasForeignKey("EventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketHiveSpaceKittens.Shared.Models.TagModel", null)
                        .WithMany()
                        .HasForeignKey("TagsTagName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventModelUserModel", b =>
                {
                    b.HasOne("TicketHiveSpaceKittens.Shared.Models.EventModel", null)
                        .WithMany()
                        .HasForeignKey("BookingsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketHiveSpaceKittens.Shared.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
