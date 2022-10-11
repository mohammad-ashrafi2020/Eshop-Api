using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class create_relation_between_product_and_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                schema: "dbo",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductId",
                schema: "dbo",
                table: "Comments",
                column: "ProductId",
                principalSchema: "product",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductId",
                schema: "dbo",
                table: "Comments");
        }
    }
}
