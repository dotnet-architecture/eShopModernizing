using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopPorted.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PictureFileName = table.Column<string>(nullable: false),
                    CatalogTypeId = table.Column<int>(nullable: false),
                    CatalogBrandId = table.Column<int>(nullable: false),
                    AvailableStock = table.Column<int>(nullable: false),
                    RestockThreshold = table.Column<int>(nullable: false),
                    MaxStockThreshold = table.Column<int>(nullable: false),
                    OnReorder = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CatalogBrand",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "Azure" },
                    { 2, ".NET" },
                    { 3, "Visual Studio" },
                    { 4, "SQL Server" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Mug" },
                    { 2, "T-Shirt" },
                    { 3, "Sheet" },
                    { 4, "USB Memory Stick" }
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "AvailableStock", "CatalogBrandId", "CatalogTypeId", "Description", "MaxStockThreshold", "Name", "OnReorder", "PictureFileName", "Price", "RestockThreshold" },
                values: new object[,]
                {
                    { 2, 100, 2, 1, ".NET Black & White Mug", 0, ".NET Black & White Mug", false, "2.png", 8.50m, 0 },
                    { 9, 100, 5, 1, "Cup<T> White Mug", 0, "Cup<T> White Mug", false, "9.png", 12m, 0 },
                    { 1, 100, 2, 2, ".NET Bot Black Hoodie", 0, ".NET Bot Black Hoodie", false, "1.png", 19.5m, 0 },
                    { 3, 100, 5, 2, "Prism White T-Shirt", 0, "Prism White T-Shirt", false, "3.png", 12m, 0 },
                    { 4, 100, 2, 2, ".NET Foundation T-shirt", 0, ".NET Foundation T-shirt", false, "4.png", 12m, 0 },
                    { 6, 100, 2, 2, ".NET Blue Hoodie", 0, ".NET Blue Hoodie", false, "6.png", 12m, 0 },
                    { 7, 100, 5, 2, "Roslyn Red T-Shirt", 0, "Roslyn Red T-Shirt", false, "7.png", 12m, 0 },
                    { 8, 100, 5, 2, "Kudu Purple Hoodie", 0, "Kudu Purple Hoodie", false, "8.png", 8.5m, 0 },
                    { 12, 100, 5, 2, "Prism White TShirt", 0, "Prism White TShirt", false, "12.png", 12m, 0 },
                    { 5, 100, 5, 3, "Roslyn Red Sheet", 0, "Roslyn Red Sheet", false, "5.png", 8.5m, 0 },
                    { 10, 100, 2, 3, ".NET Foundation Sheet", 0, ".NET Foundation Sheet", false, "10.png", 12m, 0 },
                    { 11, 100, 2, 3, "Cup<T> Sheet", 0, "Cup<T> Sheet", false, "11.png", 8.5m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogBrandId",
                table: "Catalog",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                table: "Catalog",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogBrand");

            migrationBuilder.DropTable(
                name: "CatalogType");
        }
    }
}
