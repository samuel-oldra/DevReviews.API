using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevReviews.API.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    RegisteredAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(maxLength: 50, nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    RegisteredAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_ProductReviews_tb_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tb_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ProductReviews_ProductId",
                table: "tb_ProductReviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ProductReviews");

            migrationBuilder.DropTable(
                name: "tb_Product");
        }
    }
}
