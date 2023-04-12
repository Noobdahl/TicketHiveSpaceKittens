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
    [Migration("20230405092616_InitialWithSeed")]
    partial class InitialWithSeed
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
                            TagsTagName = "Utomhus"
                        });
                });

            modelBuilder.Entity("TicketHiveSpaceKittens.Shared.Models.BookingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("Tickets")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
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
                            Description = "Fyllefest deluxe",
                            EventDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "",
                            Location = "Backyard",
                            Name = "Springbreak",
                            TicketPrice = 199m,
                            TicketsRemaining = 10
                        },
                        new
                        {
                            EventId = 2,
                            Description = "Fyllefest deluxe2",
                            EventDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "",
                            Location = "Backyard2",
                            Name = "Springbreak2",
                            TicketPrice = 1992m,
                            TicketsRemaining = 102
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
                            TagName = "Utomhus"
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

            modelBuilder.Entity("TicketHiveSpaceKittens.Shared.Models.BookingModel", b =>
                {
                    b.HasOne("TicketHiveSpaceKittens.Shared.Models.EventModel", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketHiveSpaceKittens.Shared.Models.UserModel", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketHiveSpaceKittens.Shared.Models.UserModel", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}