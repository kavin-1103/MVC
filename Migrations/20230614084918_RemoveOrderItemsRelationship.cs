using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation_Management.Migrations
{
    public partial class RemoveOrderItemsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrdersOrderID",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrdersOrderID",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrdersOrderID",
                table: "OrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersOrderID",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrdersOrderID",
                table: "OrderItems",
                column: "OrdersOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrdersOrderID",
                table: "OrderItems",
                column: "OrdersOrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");
        }
    }
}
