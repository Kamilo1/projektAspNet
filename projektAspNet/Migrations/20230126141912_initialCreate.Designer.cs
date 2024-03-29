﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projektAspNet.Models;

#nullable disable

namespace projektAspNet.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230126141912_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projektAspNet.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "MSI",
                            FirstName = "Robert",
                            LastName = "Kowalski",
                            NIP = "1111111111",
                            Pesel = "11111111111",
                            Telephone = "010101010"
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "Acer",
                            FirstName = "Marcin",
                            LastName = "Zając",
                            NIP = "2222222222",
                            Pesel = "22222222222",
                            Telephone = "020202020"
                        },
                        new
                        {
                            Id = 3,
                            CompanyName = "Intel",
                            FirstName = "Fabian",
                            LastName = "Nowak",
                            NIP = "3333333333",
                            Pesel = "33333333333",
                            Telephone = "030303030"
                        });
                });

            modelBuilder.Entity("projektAspNet.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfEvent = new DateTime(2001, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Czyszczenie rzeki Skawy",
                            EventLocation = "Wadowice"
                        },
                        new
                        {
                            Id = 2,
                            DateOfEvent = new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Dwudniowy spływ Wisłą",
                            EventLocation = "Spytkowice"
                        },
                        new
                        {
                            Id = 3,
                            DateOfEvent = new DateTime(2001, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Nocny spływ Wisłą",
                            EventLocation = "Spytkowice"
                        },
                        new
                        {
                            Id = 4,
                            DateOfEvent = new DateTime(2001, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Wielki spływ z jeziora żywieckiego",
                            EventLocation = "Żywiec"
                        });
                });

            modelBuilder.Entity("projektAspNet.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfKayaking")
                        .HasColumnType("datetime2");

                    b.Property<string>("KayakType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfKayaks")
                        .HasColumnType("int");

                    b.Property<int>("RouteID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.HasIndex("RouteID");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerID = 1,
                            DateOfKayaking = new DateTime(2001, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KayakType = "pojedynczy",
                            NumberOfKayaks = 3,
                            RouteID = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerID = 2,
                            DateOfKayaking = new DateTime(2000, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KayakType = "podwójny",
                            NumberOfKayaks = 4,
                            RouteID = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerID = 3,
                            DateOfKayaking = new DateTime(2002, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KayakType = "pojedynczy",
                            NumberOfKayaks = 2,
                            RouteID = 3
                        });
                });

            modelBuilder.Entity("projektAspNet.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Route_Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Difficulty = "Bardzo zaawansowana",
                            RouteName = "wadowice-witanowice",
                            RouteLength = "4km"
                        },
                        new
                        {
                            Id = 2,
                            Difficulty = "Zaawansowana",
                            RouteName = "wadowice-woźniki",
                            RouteLength = "5,5km"
                        },
                        new
                        {
                            Id = 3,
                            Difficulty = "Zaawansowana",
                            RouteName = "wadowice-grodzisko",
                            RouteLength = "8km"
                        },
                        new
                        {
                            Id = 4,
                            Difficulty = "Średnio zaawansowana",
                            RouteName = "witanowice-woźniki",
                            RouteLength = "6km"
                        },
                        new
                        {
                            Id = 5,
                            Difficulty = "Łatwa",
                            RouteName = "witanowice-grodzisko",
                            RouteLength = "4km"
                        },
                        new
                        {
                            Id = 6,
                            Difficulty = "Bardzo łatwa",
                            RouteName = "woźniki-grodzisko",
                            RouteLength = "2,5km"
                        });
                });

            modelBuilder.Entity("projektAspNet.Models.Customer", b =>
                {
                    b.HasOne("projektAspNet.Models.Reservation", null)
                        .WithMany("Customers")
                        .HasForeignKey("ReservationId");
                });

            modelBuilder.Entity("projektAspNet.Models.Reservation", b =>
                {
                    b.HasOne("projektAspNet.Models.Customer", "Customer")
                        .WithMany("Reservation")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projektAspNet.Models.Route", "Route")
                        .WithMany("Reservation")
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("projektAspNet.Models.Route", b =>
                {
                    b.HasOne("projektAspNet.Models.Reservation", null)
                        .WithMany("Routes")
                        .HasForeignKey("ReservationId");
                });

            modelBuilder.Entity("projektAspNet.Models.Customer", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("projektAspNet.Models.Reservation", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Routes");
                });

            modelBuilder.Entity("projektAspNet.Models.Route", b =>
                {
                    b.Navigation("Reservation");
                });
#pragma warning restore 612, 618
        }
    }
}
