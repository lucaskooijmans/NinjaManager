using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Agility", "Category", "Intelligence", "Name", "Strength", "ValueInGold" },
                values: new object[,]
                {
                    { 1, 50, "Hand", 100, "Golden Sword", 200, 10 },
                    { 2, 50, "Hand", 200, "Diamond Sword", 400, 20 },
                    { 3, 50, "Hand", 10, "Silver Sword", 100, 5 },
                    { 4, 50, "Head", 100, "Golden Hat", 200, 10 },
                    { 5, 50, "Head", 200, "Diamond Hat", 400, 20 },
                    { 6, 50, "Head", 10, "Silver Hat", 100, 5 },
                    { 7, 50, "Chest", 100, "Golden Chest", 200, 10 },
                    { 8, 50, "Chest", 200, "Diamond Chest", 400, 20 },
                    { 9, 50, "Chest", 10, "Silver Chest", 100, 5 },
                    { 10, 50, "Feet", 100, "Golden Shoes", 200, 10 },
                    { 11, 50, "Feet", 200, "Diamond Shoes", 400, 20 },
                    { 12, 50, "Feet", 10, "Silver Shoes", 100, 5 },
                    { 13, 50, "Ring", 100, "Golden Ring", 200, 10 },
                    { 14, 50, "Ring", 200, "Diamond Ring", 400, 20 },
                    { 15, 50, "Ring", 10, "Silver Ring", 100, 5 },
                    { 16, 50, "Necklace", 100, "Golden Necklace", 200, 10 },
                    { 17, 50, "Necklace", 200, "Diamond Necklace", 400, 20 },
                    { 18, 50, "Necklace", 10, "Silver Necklace", 100, 5 }
                });

            migrationBuilder.InsertData(
                table: "Ninjas",
                columns: new[] { "Id", "Gold", "Name" },
                values: new object[,]
                {
                    { 1, 999999999, "Kees" },
                    { 2, 500000, "Willem" },
                    { 3, 10000, "Jan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ninjas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ninjas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ninjas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
