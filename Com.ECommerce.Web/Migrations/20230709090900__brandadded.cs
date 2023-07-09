using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Com.ECommerce.Web.Migrations
{
    public partial class _brandadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ProductImages",
                newName: "ProductPhoto");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Product",
                newName: "ProductPhoto");

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brand_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_ProductId",
                table: "Brand",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.RenameColumn(
                name: "ProductPhoto",
                table: "ProductImages",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ProductPhoto",
                table: "Product",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
