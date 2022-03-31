using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoo.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Gender", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 13, "Female", "Gary", "Goose" },
                    { 2, 4, "Male", "Terry", "Tiger" },
                    { 3, 5, "Male", "Lawrence", "Lion" },
                    { 4, 6, "Male", "Gary2", "Goose" },
                    { 5, 39, "Female", "Penelope", "Peacock" },
                    { 6, 25, "Male", "Zane", "Zebra" },
                    { 7, 4, "Male", "Marcus", "Meerkat" },
                    { 8, 13, "Female", "Zoie", "Zebra" },
                    { 9, 6, "Female", "Sydney", "Snake" },
                    { 10, 19, "Female", "Karen", "Kimodo Dragon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 10);
        }
    }
}
