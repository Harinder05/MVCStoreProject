using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    InStockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "InStockQuantity", "ModelNumber", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Apple", "The latest iPhone with powerful features.", 10, "12", 900.0, "iPhone 12" },
                    { 2, "Samsung", "A flagship smartphone from Samsung.", 15, "S21", 850.0, "Samsung Galaxy S21" },
                    { 3, "Bose", "Noise-canceling wireless headphones.", 8, "QC35 II", 350.0, "Bose QuietComfort 35 II" },
                    { 4, "Canon", "A DSLR camera with advanced features.", 12, "EOS 80D", 1000.0, "Canon EOS 80D" },
                    { 5, "Dell", "A high-performance laptop from Dell.", 5, "XPS 13", 1300.0, "Dell XPS 13" },
                    { 6, "Lenovo", "A business-class ultrabook from Lenovo.", 3, "ThinkPad X1 Carbon", 1600.0, "Lenovo ThinkPad X1 Carbon" },
                    { 7, "Sony", "Wireless noise-canceling headphones.", 20, "WH-1000XM4", 350.0, "Sony WH-1000XM4" },
                    { 8, "Google", "A flagship smartphone from Google.", 18, "Pixel 6", 700.0, "Google Pixel 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }
    }
}
