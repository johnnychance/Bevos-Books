using Microsoft.EntityFrameworkCore.Migrations;

namespace fa18Team28_FinalProject.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_OrderCustomerOrderID",
                table: "CustomerOrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderCustomerOrderID",
                table: "CustomerOrderDetails",
                newName: "CustomerOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrderDetails_OrderCustomerOrderID",
                table: "CustomerOrderDetails",
                newName: "IX_CustomerOrderDetails_CustomerOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_CustomerOrderID",
                table: "CustomerOrderDetails",
                column: "CustomerOrderID",
                principalTable: "CustomerOrders",
                principalColumn: "CustomerOrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_CustomerOrderID",
                table: "CustomerOrderDetails");

            migrationBuilder.RenameColumn(
                name: "CustomerOrderID",
                table: "CustomerOrderDetails",
                newName: "OrderCustomerOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrderDetails_CustomerOrderID",
                table: "CustomerOrderDetails",
                newName: "IX_CustomerOrderDetails_OrderCustomerOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_OrderCustomerOrderID",
                table: "CustomerOrderDetails",
                column: "OrderCustomerOrderID",
                principalTable: "CustomerOrders",
                principalColumn: "CustomerOrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
