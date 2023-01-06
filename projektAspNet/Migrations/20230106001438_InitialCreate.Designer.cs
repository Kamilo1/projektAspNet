﻿// <auto-generated />
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
    [Migration("20230106001438_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomersReservations", b =>
                {
                    b.Property<int>("ReservationsId")
                        .HasColumnType("int");

                    b.Property<int>("customersId")
                        .HasColumnType("int");

                    b.HasKey("ReservationsId", "customersId");

                    b.HasIndex("customersId");

                    b.ToTable("CustomersReservations");
                });

            modelBuilder.Entity("CustomersRoutes", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("RoutesId")
                        .HasColumnType("int");

                    b.HasKey("CustomersId", "RoutesId");

                    b.HasIndex("RoutesId");

                    b.ToTable("CustomersRoutes");
                });

            modelBuilder.Entity("ReservationsRoutes", b =>
                {
                    b.Property<int>("ReservationsId")
                        .HasColumnType("int");

                    b.Property<int>("RoutesId")
                        .HasColumnType("int");

                    b.HasKey("ReservationsId", "RoutesId");

                    b.HasIndex("RoutesId");

                    b.ToTable("ReservationsRoutes");
                });

            modelBuilder.Entity("projektAspNet.Models.Customers", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "MSI",
                            FirstName = "Robert",
                            LastName = "Kowalski",
                            NIP = "1111111111",
                            Pesel = "11111111111"
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "Acer",
                            FirstName = "Marcin",
                            LastName = "Zając",
                            NIP = "2222222222",
                            Pesel = "22222222222"
                        },
                        new
                        {
                            Id = 3,
                            CompanyName = "Intel",
                            FirstName = "Fabian",
                            LastName = "Nowak",
                            NIP = "3333333333",
                            Pesel = "33333333333"
                        });
                });

            modelBuilder.Entity("projektAspNet.Models.Reservations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("KayakType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfKayaks")
                        .HasColumnType("int");

                    b.Property<int>("RouteID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerID = 1,
                            KayakType = "pojedynczy",
                            NumberOfKayaks = 3,
                            RouteID = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerID = 2,
                            KayakType = "podwójny",
                            NumberOfKayaks = 4,
                            RouteID = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerID = 3,
                            KayakType = "pojedynczy",
                            NumberOfKayaks = 2,
                            RouteID = 3
                        });
                });

            modelBuilder.Entity("projektAspNet.Models.Routes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RouteName = "wadowice-witanowice"
                        },
                        new
                        {
                            Id = 2,
                            RouteName = "wadowice-woźniki"
                        },
                        new
                        {
                            Id = 3,
                            RouteName = "wadowice-grodzisko"
                        },
                        new
                        {
                            Id = 4,
                            RouteName = "witanowice-woźniki"
                        },
                        new
                        {
                            Id = 5,
                            RouteName = "witanowice-grodzisko"
                        },
                        new
                        {
                            Id = 6,
                            RouteName = "woźniki-grodzisko"
                        });
                });

            modelBuilder.Entity("CustomersReservations", b =>
                {
                    b.HasOne("projektAspNet.Models.Reservations", null)
                        .WithMany()
                        .HasForeignKey("ReservationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projektAspNet.Models.Customers", null)
                        .WithMany()
                        .HasForeignKey("customersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomersRoutes", b =>
                {
                    b.HasOne("projektAspNet.Models.Customers", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projektAspNet.Models.Routes", null)
                        .WithMany()
                        .HasForeignKey("RoutesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReservationsRoutes", b =>
                {
                    b.HasOne("projektAspNet.Models.Reservations", null)
                        .WithMany()
                        .HasForeignKey("ReservationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projektAspNet.Models.Routes", null)
                        .WithMany()
                        .HasForeignKey("RoutesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
