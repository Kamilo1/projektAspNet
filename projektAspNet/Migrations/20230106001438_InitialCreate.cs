using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projektAspNet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
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
                    KayakType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfKayaks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomersReservations",
                columns: table => new
                {
                    ReservationsId = table.Column<int>(type: "int", nullable: false),
                    customersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersReservations", x => new { x.ReservationsId, x.customersId });
                    table.ForeignKey(
                        name: "FK_CustomersReservations_Customers_customersId",
                        column: x => x.customersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersReservations_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersRoutes",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    RoutesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersRoutes", x => new { x.CustomersId, x.RoutesId });
                    table.ForeignKey(
                        name: "FK_CustomersRoutes_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersRoutes_Routes_RoutesId",
                        column: x => x.RoutesId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationsRoutes",
                columns: table => new
                {
                    ReservationsId = table.Column<int>(type: "int", nullable: false),
                    RoutesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsRoutes", x => new { x.ReservationsId, x.RoutesId });
                    table.ForeignKey(
                        name: "FK_ReservationsRoutes_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationsRoutes_Routes_RoutesId",
                        column: x => x.RoutesId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CompanyName", "FirstName", "LastName", "NIP", "Pesel" },
                values: new object[,]
                {
                    { 1, "MSI", "Robert", "Kowalski", "1111111111", "11111111111" },
                    { 2, "Acer", "Marcin", "Zając", "2222222222", "22222222222" },
                    { 3, "Intel", "Fabian", "Nowak", "3333333333", "33333333333" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerID", "KayakType", "NumberOfKayaks", "RouteID" },
                values: new object[,]
                {
                    { 1, 1, "pojedynczy", 3, 1 },
                    { 2, 2, "podwójny", 4, 2 },
                    { 3, 3, "pojedynczy", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "RouteName" },
                values: new object[,]
                {
                    { 1, "wadowice-witanowice" },
                    { 2, "wadowice-woźniki" },
                    { 3, "wadowice-grodzisko" },
                    { 4, "witanowice-woźniki" },
                    { 5, "witanowice-grodzisko" },
                    { 6, "woźniki-grodzisko" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersReservations_customersId",
                table: "CustomersReservations",
                column: "customersId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersRoutes_RoutesId",
                table: "CustomersRoutes",
                column: "RoutesId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsRoutes_RoutesId",
                table: "ReservationsRoutes",
                column: "RoutesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersReservations");

            migrationBuilder.DropTable(
                name: "CustomersRoutes");

            migrationBuilder.DropTable(
                name: "ReservationsRoutes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
