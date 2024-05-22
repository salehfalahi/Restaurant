using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatefood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1833178b-1ed4-4494-b177-7fa23c978277");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a682299-b8dc-4613-b5c5-7035ae65784f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab9ee05e-3648-423d-850e-445d53dac123");

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecial",
                table: "Foods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SpecialPrice",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04054fc7-29c3-4473-990d-713ad95c85b0", null, "admin", "admin" },
                    { "d2e57a10-b707-42c8-a134-98a1904c1aae", null, "customer", "customer" },
                    { "e0238b72-e45e-4b41-baaf-9d74fc2f03a1", null, "manager", "manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04054fc7-29c3-4473-990d-713ad95c85b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2e57a10-b707-42c8-a134-98a1904c1aae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0238b72-e45e-4b41-baaf-9d74fc2f03a1");

            migrationBuilder.DropColumn(
                name: "IsSpecial",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "SpecialPrice",
                table: "Foods");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1833178b-1ed4-4494-b177-7fa23c978277", null, "customer", "customer" },
                    { "9a682299-b8dc-4613-b5c5-7035ae65784f", null, "admin", "admin" },
                    { "ab9ee05e-3648-423d-850e-445d53dac123", null, "manager", "manager" }
                });
        }
    }
}
