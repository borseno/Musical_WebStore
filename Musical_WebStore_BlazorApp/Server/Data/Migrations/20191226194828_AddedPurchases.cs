using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Musical_WebStore_BlazorApp.Server.Data.Migrations
{
    public partial class AddedPurchases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false),
                    Num = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.InstrumentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CartItems_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false),
                    Num = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrders", x => new { x.InstrumentId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ItemOrders_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1000, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 800, 9 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 500, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 400, 5 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 5 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1000, 9 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 400, 3 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 6 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 5 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1000, 5 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 600, 5 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 600, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 9 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 8 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 800, 8 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 9 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 6 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -3,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 600, 6 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 2 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { -2, "Харьков, Бакулина 45а", "Rabbit Coffe Spot (ст. м. Научная)", "+38(097)566-53-21" },
                    { -1, "Харьков, ул. Целиноградская 36б", "Rabbit Coffe Spot (ст. м. Алексеевская)", "+38(095)233-46-21" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_OrderId",
                table: "ItemOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocationId",
                table: "Orders",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ItemOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 8 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 600, 3 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 6 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 500, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 800, 3 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 3 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 3 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 400, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1000, 9 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 400, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 8 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 6 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 500, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 800, 3 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 7 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 7 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 9 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 7 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -3,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 400, 7 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 7 });
        }
    }
}
