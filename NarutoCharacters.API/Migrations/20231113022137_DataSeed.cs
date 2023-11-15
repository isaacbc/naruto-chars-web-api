using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NarutoCharacters.API.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ninjas",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The main protagonist of the series.", "Naruto Uzumaki" },
                    { 2, "Naruto's rival and a skilled ninja.", "Sasuke Uchiha" },
                    { 3, "A member of Team 7.", "Sakura Haruno" }
                });

            migrationBuilder.InsertData(
                table: "Jutsus",
                columns: new[] { "Id", "Description", "Name", "NinjaId" },
                values: new object[,]
                {
                    { 1, "A spinning ball of chakra formed and held in the palm of the user's hand.", "Rasengan", 1 },
                    { 2, "A jutsu that creates an identical copy of the user.", "Shadow Clone Jutsu", 1 },
                    { 3, "Enhances the user's physical abilities.", "Sage Mode", 1 },
                    { 4, "A high concentration of lightning chakra in the user's hand.", "Chidori", 2 },
                    { 5, "A special eye technique granting advanced visual capabilities.", "Sharingan", 2 },
                    { 6, "A jutsu that heals injuries.", "Medical Ninjutsu", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jutsus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jutsus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jutsus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jutsus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jutsus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Jutsus",
                keyColumn: "Id",
                keyValue: 6);

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
