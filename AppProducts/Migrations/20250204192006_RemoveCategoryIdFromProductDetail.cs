using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppProducts.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCategoryIdFromProductDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductsDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDetails_CategoryId",
                table: "ProductsDetails",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDetails_Categories_CategoryId",
                table: "ProductsDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDetails_Categories_CategoryId",
                table: "ProductsDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductsDetails_CategoryId",
                table: "ProductsDetails");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductsDetails");
        }
    }
}
