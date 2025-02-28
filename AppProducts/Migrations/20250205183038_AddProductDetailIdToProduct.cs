using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppProducts.Migrations
{
    /// <inheritdoc />
    public partial class AddProductDetailIdToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDetails_Categories_CategoryId",
                table: "ProductsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDetails_Products_ProductId",
                table: "ProductsDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductsDetails_CategoryId",
                table: "ProductsDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductsDetails_ProductId",
                table: "ProductsDetails");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductsDetails");

            migrationBuilder.AddColumn<int>(
                name: "ProductDetailId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products",
                column: "ProductDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsDetails_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                principalTable: "ProductsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsDetails_ProductDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductsDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDetails_CategoryId",
                table: "ProductsDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDetails_ProductId",
                table: "ProductsDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDetails_Categories_CategoryId",
                table: "ProductsDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDetails_Products_ProductId",
                table: "ProductsDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
