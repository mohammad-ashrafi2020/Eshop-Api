using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class fix_comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Sliders",
                newName: "Sliders",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ShippingMethods",
                newName: "ShippingMethods",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comments",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Banners",
                newName: "Banners",
                newSchema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "Advantages",
                schema: "dbo",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Disadvantages",
                schema: "dbo",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                schema: "dbo",
                table: "Comments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UserRecommendedStatus",
                schema: "dbo",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advantages",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Disadvantages",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Rate",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserRecommendedStatus",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Sliders",
                schema: "dbo",
                newName: "Sliders");

            migrationBuilder.RenameTable(
                name: "ShippingMethods",
                schema: "dbo",
                newName: "ShippingMethods");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "dbo",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Banners",
                schema: "dbo",
                newName: "Banners");
        }
    }
}
