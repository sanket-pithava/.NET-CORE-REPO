using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Addproductableandseedproductodatabse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "catogeries",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "A classic novel by F. Scott Fitzgerald exploring themes of wealth, love, and the American dream.", "9780743273565", 199.0, 189.0, 169.0, 179.0, "The Great Gatsby" },
                    { 2, "James Clear", "A guide to building good habits and breaking bad ones with small incremental changes.", "9780735211292", 499.0, 479.0, 439.0, 459.0, "Atomic Habits" },
                    { 3, "Robert C. Martin", "A handbook of agile software craftsmanship with practical advice for writing cleaner code.", "9780132350884", 799.0, 769.0, 699.0, 729.0, "Clean Code" },
                    { 4, "Andrew Hunt and David Thomas", "Classic guide to software engineering best practices and mindset for developers.", "9780201616224", 699.0, 669.0, 599.0, 639.0, "The Pragmatic Programmer" },
                    { 5, "Cal Newport", "A book on focused success in a distracted world, emphasizing deep concentration and productivity.", "9781455586691", 399.0, 379.0, 339.0, 359.0, "Deep Work" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "catogeries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
