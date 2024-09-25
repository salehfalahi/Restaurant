using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class neworder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte>(
                name: "Table",
                table: "Orders",
                type: "tinyint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a38551e-5101-4f3d-ad75-13969fffb93e", null, "customer", "customer" },
                    { "aae8a1d6-6857-4570-9c90-3608edc65bb6", null, "manager", "manager" },
                    { "f678b680-c199-411d-a88d-b5237fe2244d", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a38551e-5101-4f3d-ad75-13969fffb93e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aae8a1d6-6857-4570-9c90-3608edc65bb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f678b680-c199-411d-a88d-b5237fe2244d");

            migrationBuilder.DropColumn(
                name: "Table",
                table: "Orders");

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
    }
}
