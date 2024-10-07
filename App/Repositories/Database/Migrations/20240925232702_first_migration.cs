#nullable disable

namespace App.Repositories.Database.Migrations;

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class firstMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Campaigns",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Title = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                ImageUrl = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table => table.PrimaryKey("PK_Campaigns", x => x.Id))
            .Annotation("MySql:CharSet", "utf8mb4")
            .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ImageUrl = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table => table.PrimaryKey("PK_Categories", x => x.Id))
            .Annotation("MySql:CharSet", "utf8mb4")
            .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Email = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Password = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Role = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Users", x => x.Id))
            .Annotation("MySql:CharSet", "utf8mb4")
            .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Quantity = table.Column<double>(type: "double", nullable: false),
                Price = table.Column<double>(type: "double", nullable: false),
                ImageUrl = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Sales = table.Column<int>(type: "int", nullable: false),
                CategoryId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    name: "FK_Products_Categories_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4")
            .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

        migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                UserId = table.Column<int>(type: "int", nullable: false),
                TotalAmount = table.Column<double>(type: "double", nullable: false),
                Status = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
                table.ForeignKey(
                    name: "FK_Orders_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4")
            .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

        migrationBuilder.CreateTable(
            name: "CampaignProduct",
            columns: table => new
            {
                CampaignsId = table.Column<int>(type: "int", nullable: false),
                ProductsId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CampaignProduct", x => new { x.CampaignsId, x.ProductsId });
                table.ForeignKey(
                    name: "FK_CampaignProduct_Campaigns_CampaignsId",
                    column: x => x.CampaignsId,
                    principalTable: "Campaigns",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_CampaignProduct_Products_ProductsId",
                    column: x => x.ProductsId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4")
            .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

        migrationBuilder.CreateTable(
            name: "Images",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                ProductId = table.Column<int>(type: "int", nullable: true),
                FileName = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Path = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Images", x => x.Id);
                table.ForeignKey(
                    name: "FK_Images_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id");
            })
            .Annotation("MySql:CharSet", "utf8mb4")
            .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

        migrationBuilder.CreateTable(
            name: "OrderItems",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                OrderId = table.Column<int>(type: "int", nullable: false),
                ProductId = table.Column<int>(type: "int", nullable: false),
                Quantity = table.Column<double>(type: "double", nullable: false),
                Total = table.Column<double>(type: "double", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_OrderItems_Orders_OrderId",
                    column: x => x.OrderId,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_OrderItems_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4")
            .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

        migrationBuilder.CreateIndex(
            name: "IX_CampaignProduct_ProductsId",
            table: "CampaignProduct",
            column: "ProductsId");

        migrationBuilder.CreateIndex(
            name: "IX_Images_ProductId",
            table: "Images",
            column: "ProductId");

        migrationBuilder.CreateIndex(
            name: "IX_OrderItems_OrderId",
            table: "OrderItems",
            column: "OrderId");

        migrationBuilder.CreateIndex(
            name: "IX_OrderItems_ProductId",
            table: "OrderItems",
            column: "ProductId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_UserId",
            table: "Orders",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_CategoryId",
            table: "Products",
            column: "CategoryId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CampaignProduct");

        migrationBuilder.DropTable(
            name: "Images");

        migrationBuilder.DropTable(
            name: "OrderItems");

        migrationBuilder.DropTable(
            name: "Campaigns");

        migrationBuilder.DropTable(
            name: "Orders");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "Categories");
    }
}
