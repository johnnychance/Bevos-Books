using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fa18Team28_FinalProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    CreditCard1 = table.Column<int>(nullable: false),
                    CreditCard2 = table.Column<int>(nullable: false),
                    CreditCard3 = table.Column<int>(nullable: false),
                    NumberofOrders = table.Column<int>(nullable: false),
                    ReviewsWritten = table.Column<string>(nullable: true),
                    ReviewsApproved = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublishedDate = table.Column<DateTime>(nullable: false),
                    UniqueID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Reordered = table.Column<int>(nullable: false),
                    CopiesOnHand = table.Column<int>(nullable: false),
                    LastOrdered = table.Column<DateTime>(nullable: false),
                    GenreID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    CustomerOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerOrderDate = table.Column<DateTime>(nullable: false),
                    CustomerOrderNotes = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => x.CustomerOrderID);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerOrder",
                columns: table => new
                {
                    ManagerOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManagerOrderDate = table.Column<DateTime>(nullable: false),
                    ManagerOrderDetailNotes = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerOrder", x => x.ManagerOrderID);
                    table.ForeignKey(
                        name: "FK_ManagerOrder_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderDetail",
                columns: table => new
                {
                    CustomerOrderDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ExtendedPrice = table.Column<decimal>(nullable: false),
                    CustomerOrderDetailNotes = table.Column<int>(nullable: false),
                    OrderCustomerOrderID = table.Column<int>(nullable: true),
                    BookID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrderDetail", x => x.CustomerOrderDetailID);
                    table.ForeignKey(
                        name: "FK_CustomerOrderDetail_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerOrderDetail_CustomerOrder_OrderCustomerOrderID",
                        column: x => x.OrderCustomerOrderID,
                        principalTable: "CustomerOrder",
                        principalColumn: "CustomerOrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountDetail",
                columns: table => new
                {
                    DiscountDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerOrderID = table.Column<int>(nullable: true),
                    DiscountID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountDetail", x => x.DiscountDetailID);
                    table.ForeignKey(
                        name: "FK_DiscountDetail_CustomerOrder_CustomerOrderID",
                        column: x => x.CustomerOrderID,
                        principalTable: "CustomerOrder",
                        principalColumn: "CustomerOrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountDetail_Discount_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discount",
                        principalColumn: "DiscountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerOrderDetail",
                columns: table => new
                {
                    ManagerOrderDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    ProductCost = table.Column<decimal>(nullable: false),
                    ExtendedCost = table.Column<decimal>(nullable: false),
                    ManagerOrderDetailsNotes = table.Column<int>(nullable: false),
                    ManagerOrderID = table.Column<int>(nullable: true),
                    BookID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerOrderDetail", x => x.ManagerOrderDetailID);
                    table.ForeignKey(
                        name: "FK_ManagerOrderDetail_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagerOrderDetail_ManagerOrder_ManagerOrderID",
                        column: x => x.ManagerOrderID,
                        principalTable: "ManagerOrder",
                        principalColumn: "ManagerOrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreID",
                table: "Books",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_UserID",
                table: "CustomerOrder",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderDetail_BookID",
                table: "CustomerOrderDetail",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderDetail_OrderCustomerOrderID",
                table: "CustomerOrderDetail",
                column: "OrderCustomerOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountDetail_CustomerOrderID",
                table: "DiscountDetail",
                column: "CustomerOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountDetail_DiscountID",
                table: "DiscountDetail",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerOrder_UserID",
                table: "ManagerOrder",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerOrderDetail_BookID",
                table: "ManagerOrderDetail",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerOrderDetail_ManagerOrderID",
                table: "ManagerOrderDetail",
                column: "ManagerOrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrderDetail");

            migrationBuilder.DropTable(
                name: "DiscountDetail");

            migrationBuilder.DropTable(
                name: "ManagerOrderDetail");

            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ManagerOrder");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
