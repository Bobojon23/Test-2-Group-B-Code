using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test_2_Group_B_Code.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "BirthYear", "Country", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1798, "Poland", "Adam", "Mickiewicz" },
                    { 2, 1775, "United Kingdom", "Jane", "Austen" },
                    { 3, 1927, "Colombia", "Gabriel", "Garcia Marquez" },
                    { 4, 1949, "Japan", "Haruki", "Murakami" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "ISBN", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, "9781234567890", 1834, "Pan Tadeusz" },
                    { 2, 2, "9789876543210", 1813, "Pride and Prejudice" },
                    { 3, 3, "9781122334455", 1967, "One Hundred Years of Solitude" },
                    { 4, 4, "9785566778899", 1987, "Norwegian Wood" },
                    { 5, 2, "9783344556677", 1811, "Sense and Sensibility" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);
        }
    }
}
