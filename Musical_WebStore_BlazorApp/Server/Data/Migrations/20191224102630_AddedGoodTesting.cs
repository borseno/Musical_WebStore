using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Musical_WebStore_BlazorApp.Server.Data.Migrations
{
    public partial class AddedGoodTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Testings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testings_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Testings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -20,
                column: "Quantity",
                value: 8);

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
                column: "Quantity",
                value: 3);

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
                column: "Quantity",
                value: 10);

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
                column: "Quantity",
                value: 9);

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
                column: "Quantity",
                value: 6);

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
                column: "Price",
                value: 700);

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
                column: "Quantity",
                value: 1);

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
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 3 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Testings_InstrumentId",
                table: "Testings",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_UserId",
                table: "Testings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testings");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -20,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 400, 9 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 3 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 6 });

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
                values: new object[] { 100, 8 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -14,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -12,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 600, 7 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -30,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 500, 5 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -27,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 500, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -25,
                column: "Price",
                value: 400);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 900, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 500, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 600, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 600, 8 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -9,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 500, 8 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 600, 3 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1000, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 500, 5 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 6 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1000, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 10 });
        }
    }
}
