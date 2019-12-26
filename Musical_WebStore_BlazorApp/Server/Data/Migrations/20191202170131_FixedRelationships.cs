using Microsoft.EntityFrameworkCore.Migrations;

namespace Musical_WebStore_BlazorApp.Server.Data.Migrations
{
    public partial class FixedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserLimited_UserId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "UserLimited");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stars",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Stars");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Stars",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stars",
                table: "Stars",
                columns: new[] { "InstrumentId", "AuthorId" });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -19,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -18,
                column: "Quantity",
                value: 3);

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
                column: "Price",
                value: 200);

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
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -13,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 1 });

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
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1000, 4 });

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
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 10 });

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
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 400, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -24,
                column: "Price",
                value: 900);

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
                column: "Price",
                value: 600);

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
                column: "Quantity",
                value: 6);

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

            migrationBuilder.CreateIndex(
                name: "IX_Stars_AuthorId",
                table: "Stars",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_InstrumentId",
                table: "Comments",
                column: "InstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Instruments_InstrumentId",
                table: "Comments",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_AspNetUsers_AuthorId",
                table: "Stars",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_Instruments_InstrumentId",
                table: "Stars",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Instruments_InstrumentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stars_AspNetUsers_AuthorId",
                table: "Stars");

            migrationBuilder.DropForeignKey(
                name: "FK_Stars_Instruments_InstrumentId",
                table: "Stars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stars",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Stars_AuthorId",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Comments_InstrumentId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Stars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Stars",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stars",
                table: "Stars",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserLimited",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLimited", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -19,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -18,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1000, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -16,
                column: "Price",
                value: 900);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 400, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 10 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -13,
                column: "Price",
                value: 600);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 6 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 4 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 700, 5 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 8 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 800, 6 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 800, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 800, 7 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 500, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -24,
                column: "Price",
                value: 700);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 800, 5 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 7 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -21,
                column: "Price",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 2 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -9,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 600, 7 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 300, 9 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 8 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1000, 7 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -4,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 1 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 200, 6 });

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 100, 8 });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserLimited_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "UserLimited",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
