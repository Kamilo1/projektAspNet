using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projektAspNet.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventLocation = table.Column<string>(name: "Event_Location", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    DateOfKayaking = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KayakType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfKayaks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteLength = table.Column<string>(name: "Route_Length", type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CompanyName", "FirstName", "LastName", "NIP", "Pesel", "ReservationId", "Telephone" },
                values: new object[,]
                {
                    { 1, "MSI", "Robert", "Kowalski", "1111111111", "11111111111", null, "010101010" },
                    { 2, "Acer", "Marcin", "Zając", "2222222222", "22222222222", null, "020202020" },
                    { 3, "Intel", "Fabian", "Nowak", "3333333333", "33333333333", null, "030303030" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "DateOfEvent", "EventName", "Event_Location" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czyszczenie rzeki Skawy", "Wadowice" },
                    { 2, new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwudniowy spływ Wisłą", "Spytkowice" },
                    { 3, new DateTime(2001, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nocny spływ Wisłą", "Spytkowice" },
                    { 4, new DateTime(2001, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wielki spływ z jeziora żywieckiego", "Żywiec" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Difficulty", "ReservationId", "RouteName", "Route_Length" },
                values: new object[,]
                {
                    { 1, "Bardzo zaawansowana", null, "wadowice-witanowice", "4km" },
                    { 2, "Zaawansowana", null, "wadowice-woźniki", "5,5km" },
                    { 3, "Zaawansowana", null, "wadowice-grodzisko", "8km" },
                    { 4, "Średnio zaawansowana", null, "witanowice-woźniki", "6km" },
                    { 5, "Łatwa", null, "witanowice-grodzisko", "4km" },
                    { 6, "Bardzo łatwa", null, "woźniki-grodzisko", "2,5km" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerID", "DateOfKayaking", "KayakType", "NumberOfKayaks", "RouteID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2001, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "pojedynczy", 3, 1 },
                    { 2, 2, new DateTime(2000, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "podwójny", 4, 2 },
                    { 3, 3, new DateTime(2002, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "pojedynczy", 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ReservationId",
                table: "Customers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerID",
                table: "Reservations",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RouteID",
                table: "Reservations",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ReservationId",
                table: "Routes",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Reservations_ReservationId",
                table: "Customers",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Routes_RouteID",
                table: "Reservations",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Reservations_ReservationId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Reservations_ReservationId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
