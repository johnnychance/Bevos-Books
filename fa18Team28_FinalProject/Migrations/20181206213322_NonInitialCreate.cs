using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fa18Team28_FinalProject.Migrations
{
    public partial class NonInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "Discounts",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "DiscountCode",
                table: "Discounts",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Discounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "DiscountDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartItemItemID",
                table: "CustomerOrderDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderDetails_CartItemItemID",
                table: "CustomerOrderDetails",
                column: "CartItemItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_CartItems_CartItemItemID",
                table: "CustomerOrderDetails",
                column: "CartItemItemID",
                principalTable: "CartItems",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_CartItems_CartItemItemID",
                table: "CustomerOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrderDetails_CartItemItemID",
                table: "CustomerOrderDetails");

            migrationBuilder.DropColumn(
                name: "DiscountCode",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CartItemItemID",
                table: "CustomerOrderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "DiscountID",
                table: "Discounts",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "DiscountID",
                table: "DiscountDetails",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
