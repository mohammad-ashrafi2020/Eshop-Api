using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class add_brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Schema",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Schema",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                schema: "product",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                schema: "product",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                schema: "dbo",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "BrandId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Introduction",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageName",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Schema",
                schema: "product",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Schema",
                schema: "dbo",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
