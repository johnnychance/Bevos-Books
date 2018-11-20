using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fa18Team28_FinalProject.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_User_UserID",
                table: "CustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetail_Books_BookID",
                table: "CustomerOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetail_CustomerOrder_OrderCustomerOrderID",
                table: "CustomerOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountDetail_CustomerOrder_CustomerOrderID",
                table: "DiscountDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountDetail_Discount_DiscountID",
                table: "DiscountDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagerOrder_User_UserID",
                table: "ManagerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagerOrderDetail_Books_BookID",
                table: "ManagerOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagerOrderDetail_ManagerOrder_ManagerOrderID",
                table: "ManagerOrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManagerOrderDetail",
                table: "ManagerOrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManagerOrder",
                table: "ManagerOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountDetail",
                table: "DiscountDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discount",
                table: "Discount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrderDetail",
                table: "CustomerOrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrder",
                table: "CustomerOrder");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "ManagerOrderDetail",
                newName: "ManagerOrderDetails");

            migrationBuilder.RenameTable(
                name: "ManagerOrder",
                newName: "ManagerOrders");

            migrationBuilder.RenameTable(
                name: "DiscountDetail",
                newName: "DiscountDetails");

            migrationBuilder.RenameTable(
                name: "Discount",
                newName: "Discounts");

            migrationBuilder.RenameTable(
                name: "CustomerOrderDetail",
                newName: "CustomerOrderDetails");

            migrationBuilder.RenameTable(
                name: "CustomerOrder",
                newName: "CustomerOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ManagerOrderDetail_ManagerOrderID",
                table: "ManagerOrderDetails",
                newName: "IX_ManagerOrderDetails_ManagerOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_ManagerOrderDetail_BookID",
                table: "ManagerOrderDetails",
                newName: "IX_ManagerOrderDetails_BookID");

            migrationBuilder.RenameIndex(
                name: "IX_ManagerOrder_UserID",
                table: "ManagerOrders",
                newName: "IX_ManagerOrders_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountDetail_DiscountID",
                table: "DiscountDetails",
                newName: "IX_DiscountDetails_DiscountID");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountDetail_CustomerOrderID",
                table: "DiscountDetails",
                newName: "IX_DiscountDetails_CustomerOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrderDetail_OrderCustomerOrderID",
                table: "CustomerOrderDetails",
                newName: "IX_CustomerOrderDetails_OrderCustomerOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrderDetail_BookID",
                table: "CustomerOrderDetails",
                newName: "IX_CustomerOrderDetails_BookID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrder_UserID",
                table: "CustomerOrders",
                newName: "IX_CustomerOrders_UserID");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseCount",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManagerOrderDetails",
                table: "ManagerOrderDetails",
                column: "ManagerOrderDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManagerOrders",
                table: "ManagerOrders",
                column: "ManagerOrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountDetails",
                table: "DiscountDetails",
                column: "DiscountDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "DiscountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrderDetails",
                table: "CustomerOrderDetails",
                column: "CustomerOrderDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrders",
                table: "CustomerOrders",
                column: "CustomerOrderID");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReviewText = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Author_user = table.Column<string>(nullable: true),
                    Approver_user = table.Column<string>(nullable: true),
                    AuthorUserID = table.Column<int>(nullable: true),
                    ApproverUserID = table.Column<int>(nullable: true),
                    BookID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ApproverUserID",
                        column: x => x.ApproverUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_AuthorUserID",
                        column: x => x.AuthorUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApproverUserID",
                table: "Reviews",
                column: "ApproverUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorUserID",
                table: "Reviews",
                column: "AuthorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookID",
                table: "Reviews",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_Books_BookID",
                table: "CustomerOrderDetails",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_OrderCustomerOrderID",
                table: "CustomerOrderDetails",
                column: "OrderCustomerOrderID",
                principalTable: "CustomerOrders",
                principalColumn: "CustomerOrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Users_UserID",
                table: "CustomerOrders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountDetails_CustomerOrders_CustomerOrderID",
                table: "DiscountDetails",
                column: "CustomerOrderID",
                principalTable: "CustomerOrders",
                principalColumn: "CustomerOrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountDetails_Discounts_DiscountID",
                table: "DiscountDetails",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerOrderDetails_Books_BookID",
                table: "ManagerOrderDetails",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerOrderDetails_ManagerOrders_ManagerOrderID",
                table: "ManagerOrderDetails",
                column: "ManagerOrderID",
                principalTable: "ManagerOrders",
                principalColumn: "ManagerOrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerOrders_Users_UserID",
                table: "ManagerOrders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_Books_BookID",
                table: "CustomerOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_OrderCustomerOrderID",
                table: "CustomerOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Users_UserID",
                table: "CustomerOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountDetails_CustomerOrders_CustomerOrderID",
                table: "DiscountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountDetails_Discounts_DiscountID",
                table: "DiscountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagerOrderDetails_Books_BookID",
                table: "ManagerOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagerOrderDetails_ManagerOrders_ManagerOrderID",
                table: "ManagerOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagerOrders_Users_UserID",
                table: "ManagerOrders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManagerOrders",
                table: "ManagerOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManagerOrderDetails",
                table: "ManagerOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountDetails",
                table: "DiscountDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrders",
                table: "CustomerOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrderDetails",
                table: "CustomerOrderDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseCount",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "ManagerOrders",
                newName: "ManagerOrder");

            migrationBuilder.RenameTable(
                name: "ManagerOrderDetails",
                newName: "ManagerOrderDetail");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discount");

            migrationBuilder.RenameTable(
                name: "DiscountDetails",
                newName: "DiscountDetail");

            migrationBuilder.RenameTable(
                name: "CustomerOrders",
                newName: "CustomerOrder");

            migrationBuilder.RenameTable(
                name: "CustomerOrderDetails",
                newName: "CustomerOrderDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ManagerOrders_UserID",
                table: "ManagerOrder",
                newName: "IX_ManagerOrder_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ManagerOrderDetails_ManagerOrderID",
                table: "ManagerOrderDetail",
                newName: "IX_ManagerOrderDetail_ManagerOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_ManagerOrderDetails_BookID",
                table: "ManagerOrderDetail",
                newName: "IX_ManagerOrderDetail_BookID");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountDetails_DiscountID",
                table: "DiscountDetail",
                newName: "IX_DiscountDetail_DiscountID");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountDetails_CustomerOrderID",
                table: "DiscountDetail",
                newName: "IX_DiscountDetail_CustomerOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrders_UserID",
                table: "CustomerOrder",
                newName: "IX_CustomerOrder_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrderDetails_OrderCustomerOrderID",
                table: "CustomerOrderDetail",
                newName: "IX_CustomerOrderDetail_OrderCustomerOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrderDetails_BookID",
                table: "CustomerOrderDetail",
                newName: "IX_CustomerOrderDetail_BookID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManagerOrder",
                table: "ManagerOrder",
                column: "ManagerOrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManagerOrderDetail",
                table: "ManagerOrderDetail",
                column: "ManagerOrderDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discount",
                table: "Discount",
                column: "DiscountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountDetail",
                table: "DiscountDetail",
                column: "DiscountDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrder",
                table: "CustomerOrder",
                column: "CustomerOrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrderDetail",
                table: "CustomerOrderDetail",
                column: "CustomerOrderDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_User_UserID",
                table: "CustomerOrder",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetail_Books_BookID",
                table: "CustomerOrderDetail",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetail_CustomerOrder_OrderCustomerOrderID",
                table: "CustomerOrderDetail",
                column: "OrderCustomerOrderID",
                principalTable: "CustomerOrder",
                principalColumn: "CustomerOrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountDetail_CustomerOrder_CustomerOrderID",
                table: "DiscountDetail",
                column: "CustomerOrderID",
                principalTable: "CustomerOrder",
                principalColumn: "CustomerOrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountDetail_Discount_DiscountID",
                table: "DiscountDetail",
                column: "DiscountID",
                principalTable: "Discount",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerOrder_User_UserID",
                table: "ManagerOrder",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerOrderDetail_Books_BookID",
                table: "ManagerOrderDetail",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerOrderDetail_ManagerOrder_ManagerOrderID",
                table: "ManagerOrderDetail",
                column: "ManagerOrderID",
                principalTable: "ManagerOrder",
                principalColumn: "ManagerOrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
