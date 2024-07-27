using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCrm.Data.Migrations
{
    public partial class renameOrioOfOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderSelectedMarketers_OrderTypeOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderTypeOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderTypeOrderId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "MobilePhone",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderType",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Cursomers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "MobilePhone",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<long>(
                name: "OrderTypeOrderId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Cursomers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderTypeOrderId",
                table: "Orders",
                column: "OrderTypeOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderSelectedMarketers_OrderTypeOrderId",
                table: "Orders",
                column: "OrderTypeOrderId",
                principalTable: "OrderSelectedMarketers",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
